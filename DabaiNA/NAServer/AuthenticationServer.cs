﻿using DabaiNA.Common;
using DabaiNA.DAL;
using DabaiNA.Modes;
using DabaiNA.NAServer;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DabaiNA.HWAuthentication
{
    class AuthenticationServer
    {
        internal static string AppID = Config.GetValue("appID");
        internal static string AppSecret = Config.GetValue("appSecret");
        public static AuthorizationMode Auth = new AuthorizationMode();
        public static Int32 httpStatusCode = -1;

        /// <summary>
        /// 定时查询刷新Token
        /// </summary>
        public static void getNewTokenFromAPI()
        {
            int loginNGCount = 0;
            while (Runtime.m_IsRefreshToken)
            {
                try
                {
                    // 调用封装北向接口的功能 API
                    if (AuthenticationServer.Login())
                    {
                        
                        loginNGCount = 0;
                        LogHelper.log.Info("*** 刷新 Token成功 *** accessToken：" + AuthenticationServer.Auth.AccessToken);
                        Runtime.ShowLog("*** 刷新 Token成功 ***");


                        long pageNo = 0;
                        long pageSize = 50;
                        //获取当天0时0分0秒UTC时间（当天0时0分0秒），
                        DateTime utcNow = DateTime.UtcNow.AddHours(-DateTime.UtcNow.Hour).AddMinutes(-DateTime.UtcNow.Minute).AddSeconds(-DateTime.UtcNow.Second);
                        string QueryResult = DataCollectionServer.QueryDevice(pageNo, pageSize, utcNow.ToString("yyyyMMddTHHmmssZ"));

                        JObject jObj = JObject.Parse(QueryResult);
                        QueryDevicesMode queryDevices = new QueryDevicesMode();
                        queryDevices = Newtonsoft.Json.JsonConvert.DeserializeObject<QueryDevicesMode>(QueryResult);
                        LogHelper.log.Info("查询当前平台中设备返回内容:" + jObj.ToString());
                        //Runtime.ShowLog("查询当前平台中设备:" + jObj.ToString());
                        if (queryDevices.totalCount > 0)
                        {
                            int reslut = DataCollectionDAL.SaveDevices(queryDevices);
                            LogHelper.log.Info(" 查询到的设备 存入数据库，总共：" + reslut + "设备");
                            Runtime.ShowLog(" 查询到的设备 存入数据库，总共：" + reslut + "设备");
                        }

                        //间隔20分钟刷新一次Token
                        System.Threading.Thread.Sleep(1200000);
                    }
                    else
                    {
                        Runtime.ShowLog("！！！刷新 Token失败失败 ！！！,准备再次尝试登录...");
                        LogHelper.log.Error("！！！ 刷新 Token失败失败 ！！！,准备再次尝试登录...");
                        //登录失败，则1分钟刷新一次Token
                        System.Threading.Thread.Sleep(60000);
                    }
                    


                    continue;

                }
                catch (Exception ex)
                {
                    Runtime.ShowLog("！！！ 刷新 Token失败失败 ！！！,准备再次尝试登录...  详细：" + ex.Message);
                    LogHelper.log.Error("！！！ 刷新 Token失败失败 ！！！,准备再次尝试登录...  详细：" + ex.Message);
                    System.Threading.Thread.Sleep(30000);
                    continue;
                }
            }

        }


        public static bool Login()
        {
            // 利用北向接口获取信息
            string lContent = GetNorthAPIContent("sec/v1.1.0/login", "POST", $"appId={AppID}&secret={AppSecret}");
            if (string.IsNullOrEmpty(lContent))
            {
                LogHelper.log.Error("！！！ 请求响应的状态码：" + httpStatusCode + "  详细：请求返回结果为空");
                return false;
            }
            LogHelper.log.Info("请求响应的状态码：" + lContent);
            // lContent 里包含了 Json 格式的 accessToken 等信息，可获取用于后续操作。最好存在全局静态变量中。
            Auth = Newtonsoft.Json.JsonConvert.DeserializeObject<AuthorizationMode>(lContent);

            return true;

        }


        public static bool RefreshToken()
        {
            RefreshTokenMode refresh = new RefreshTokenMode();
            refresh.appId = AppID;
            refresh.secret = AppSecret;
            refresh.refreshToken = Auth.RefreshToken;

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(refresh, Newtonsoft.Json.Formatting.Indented);

            // 利用北向接口获取信息

            string RefreshString = GetNorthAPIContent("sec/v1.1.0/refreshToken", "POST", json);
            if (string.IsNullOrEmpty(RefreshString))
            {
                LogHelper.log.Error(" 详细：请求返回结果为空,刷新Token失败！！！");
                return false;
            }

            Auth = Newtonsoft.Json.JsonConvert.DeserializeObject<AuthorizationMode>(RefreshString);
            Console.WriteLine(value: " refresh_OK");

            return true;
        }

        /// <summary>
        /// 2个参数
        /// </summary>
        /// <param name="aCommand"></param>
        /// <param name="aMethod"></param>
        /// <param name="aPostData"></param>
        /// <returns></returns>
        public static string GetNorthAPIContent(string aCommand, string aMethod)
        {
            // 所谓调用北向接口，实际是通过传统的方式调用一个北向给定的网址加指定的 path，并获取返回的内容。
            // 北向要求使用 https，需要给定一个证书。
            // 这里的处理方法是，将证书文件作为项目的资源文件（这样会自动以byte[] 方式读取），名称起名为 ClientCertificate（名称是随意的）。
            return GetWebResponseContent($"https://180.101.147.89:8743/iocm/app/{aCommand}", aMethod, new X509Certificate2(Properties.Resources.ClientCertificate, "IoM@1234"));
        }

        private static string GetWebResponseContent(string aURL, string aMethod, X509Certificate2 aCertificate)
        {
            HttpWebRequest lRequest = WebRequest.Create(aURL) as HttpWebRequest;
            string lContent = string.Empty;
            lRequest.Headers.Add("app_key", AppID);
            lRequest.Headers.Add("Authorization", $"Bearer {Auth.AccessToken}");
            lRequest.KeepAlive = true;
            lRequest.Method = aMethod;

            // 其实使用证书，关键就在下面这句话了。其他的语句，基本都是例行程序。
            if (aCertificate != null)
                lRequest.ClientCertificates.Add(aCertificate);
            lRequest.ContentType = "application/json";
            try
            {
                HttpWebResponse lResponse = (HttpWebResponse)lRequest.GetResponse();
                httpStatusCode = (int)lResponse.StatusCode;
                StreamReader sr = new StreamReader(lResponse.GetResponseStream(), Encoding.UTF8);
                lContent = sr.ReadToEnd();
                lResponse.Close();
            }
            catch (Exception ex)
            {
                LogHelper.log.Error("！！！ 请求响应的状态码：" + httpStatusCode + "  详细：" + ex.Message);
                throw new Exception(ex.Message);
            }

            return lContent;
        }




        public static string GetNorthAPIContent(string aCommand, string aMethod, string aPostData)
        {
            // 所谓调用北向接口，实际是通过传统的方式调用一个北向给定的网址加指定的 path，并获取返回的内容。
            // 北向要求使用 https，需要给定一个证书。
            // 这里的处理方法是，将证书文件作为项目的资源文件（这样会自动以byte[] 方式读取），名称起名为 ClientCertificate（名称是随意的）。
            return GetWebResponseContent($"https://180.101.147.89:8743/iocm/app/{aCommand}", aMethod, aPostData, new X509Certificate2(Properties.Resources.ClientCertificate, "IoM@1234"));
        }

        private static string GetWebResponseContent(string aURL, string aMethod, string aPostData, X509Certificate2 aCertificate)
        {
            HttpWebRequest lRequest = WebRequest.Create(aURL) as HttpWebRequest;
            string lContent = string.Empty;
            lRequest.Headers.Add("app_key", AppID);
            lRequest.Headers.Add("Authorization", $"Bearer {Auth.AccessToken}");
            lRequest.KeepAlive = true;
            lRequest.Method = aMethod;

            try
            {
                // 其实使用证书，关键就在下面这句话了。其他的语句，基本都是例行程序。
                if (aCertificate != null)
                {
                    lRequest.ClientCertificates.Add(aCertificate);
                }
                else
                {
                    LogHelper.log.Error("！！！ 异常：访问证书为空，请检查证书是否存在...");
                }

                if (aPostData != null)
                {
                    if (aPostData.StartsWith("{"))
                        lRequest.ContentType = "application/json";
                    else
                        lRequest.ContentType = "application/x-www-form-urlencoded";

                    byte[] lPushData = Encoding.UTF8.GetBytes(aPostData);
                    Stream lRequestStream = lRequest.GetRequestStream();
                    lRequestStream.Write(lPushData, 0, lPushData.Length);
                    lRequestStream.Close();
                }

                HttpWebResponse lResponse = (HttpWebResponse)lRequest.GetResponse();
                httpStatusCode = (int)lResponse.StatusCode;
                StreamReader sr = new StreamReader(lResponse.GetResponseStream(), Encoding.UTF8);
                lContent = sr.ReadToEnd();
                lResponse.Close();

            }
            catch (Exception ex)
            {
                LogHelper.log.Error("！！！ 请求响应的状态码：" + httpStatusCode + "  详细：" + ex.Message);
                throw new Exception(ex.Message);
            }
            return lContent;
        }
    }
}
