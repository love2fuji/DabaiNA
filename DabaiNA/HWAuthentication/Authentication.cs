﻿using System;
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
    class Authentication
    {
        internal static string AppID = "MIt_Rzhy8LmMT06Cdqtlu5OfEFka";
        internal static string AppSecret = "a6M63PugBjF8gbsaiQ8OQSyccIYa";
        internal static string NorthAccessToken = string.Empty;

        public static bool Login()
        {
            // 利用北向接口获取信息
            string lContent = GetNorthAPIContent("sec/v1.1.0/login", "POST", $"appId={AppID}&secret={AppSecret}");
            if (string.IsNullOrEmpty(lContent))
                return false;

            // lContent 里包含了 Json 格式的 accessToken 等信息，可获取用于后续操作。最好存在全局静态变量中。
            // 这里假设在 NorthAccessToken 中。
            NorthAccessToken = lContent;
            Console.WriteLine(value: " response:" + lContent);
            return true;
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

            lRequest.Headers.Add("app_key", AppID);
            lRequest.Headers.Add("Authorization", $"Bearer {NorthAccessToken}");
            lRequest.KeepAlive = true;
            lRequest.Method = aMethod;

            // 其实使用证书，关键就在下面这句话了。其他的语句，基本都是例行程序。
            if (aCertificate != null)
                lRequest.ClientCertificates.Add(aCertificate);

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

            string lContent = string.Empty;
            try
            {
                HttpWebResponse lResponse = (HttpWebResponse)lRequest.GetResponse();
                StreamReader sr = new StreamReader(lResponse.GetResponseStream(), Encoding.Default);
                lContent = sr.ReadToEnd();
                lResponse.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lContent;
        }
    }
}