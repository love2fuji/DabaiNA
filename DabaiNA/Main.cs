﻿using DabaiNA.Common;
using DabaiNA.DAL;
using DabaiNA.HWAuthentication;
using DabaiNA.Modes;
using DabaiNA.NAServer;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DabaiNA
{
    public partial class Main : Form
    {
        

        public Main()
        {
            InitializeComponent();
        }
        //日志记录的事件委托声明
        private delegate void ShowLogEventHandler(string info);

        private static DevicesMode device = new DevicesMode();

        internal static DevicesMode Device { get => device; set => device = value; }

        private void Main_Load(object sender, EventArgs e)
        {
            Runtime.ServerLog = this.ServerLog;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            Runtime.m_IsRunning = false;
            Runtime.m_IsRefreshToken = true;

            

        }

        private void btnRegisterDevice_Click(object sender, EventArgs e)
        {
            //注册直连设备
            string nodeId = "SH_Door_201805112145";
            string registerResult = DevicesManage.RegisterDirectlyConnectedDevice(nodeId);
            device = Newtonsoft.Json.JsonConvert.DeserializeObject<DevicesMode>(registerResult);
            Runtime.ShowLog("注册成功：" + registerResult);
            Runtime.ShowLog("请求响应的状态码：" + Authentication.httpStatusCode);

            Console.WriteLine("注册成功，设备ID：" + device.deviceId);
        }

        private void btnQueryDeviceStatus_Click(object sender, EventArgs e)
        {
            //查询设备激活状态
            string deviceId = "a823fc09-e119-4caa-af1b-f7f3f0eb4593";
            string deviceStatus = DevicesManage.QueryDeviceActivationStatus(deviceId);

            Runtime.ShowLog(deviceStatus);
            Runtime.ShowLog("请求响应的状态码：" + Authentication.httpStatusCode);
        }

        private void btnDeleteDevice_Click(object sender, EventArgs e)
        {
            //删除设备
            string deviceId = "49cf5244-8fe4-430d-950a-cdc6a2b13eb5";
            string deleteResult = DevicesManage.DeleteDirectlyConnectedDevice(deviceId);
            Runtime.ShowLog(deleteResult);
            Runtime.ShowLog("请求响应的状态码：" + Authentication.httpStatusCode);
        }

        private void btnModifyDeviceInfo_Click(object sender, EventArgs e)
        {

            //修改设备信息
            //string deviceId = "49cf5244-8fe4-430d-950a-cdc6a2b13eb5";
            //ModifyDeviceInfoMode modifyDeviceInfoMode = new ModifyDeviceInfoMode();

            //string deleteResult = DevicesManage.ModifyDeviceInfo(device.deviceId, modifyDeviceInfoMode);
            //ShowLog(deleteResult);
            //ShowLog("请求响应的状态码：" + Authentication.httpStatusCode);

            //ShowLog("queryDevices:" + queryDevices.totalCount);
            //ShowLog("queryDevices:" + queryDevices.totalCount);

            //查询一个设备历史数据
            string deviceId = "a823fc09-e119-4caa-af1b-f7f3f0eb4593";
            string startTime = "20180521T114027Z";
            string endTime = "20180522T224044Z";

            string buildID = "10002000";

            //将UTC时间 转换成 当前计算机所在时区的时间(即:北京时间)   
            DateTime dateISO8602 = DateTime.ParseExact(startTime, "yyyyMMddTHHmmssZ",
                                System.Globalization.CultureInfo.InvariantCulture);
            Runtime.ShowLog("----- dateISO8602:" + dateISO8602.ToString("yyyy-MM-dd HH:mm:ss"));

            //TimeZone类表示时区，TimeZone.CurrentTimeZone方法：获取当前计算机的时区。
            TimeZone tz = TimeZone.CurrentTimeZone;
            DateTime dateTime = DateTime.Now;
            //将当前计算机所在时区的时间(即:北京时间) 转换成UTC时间  
            DateTime dtGMT = tz.ToUniversalTime(dateTime);

            Runtime.ShowLog("----- dateISO8601:" + dtGMT.ToString("yyyyMMddTHHmmssZ"));


            string QueryData = DataCollection.QueryDeviceHistoryData(deviceId, deviceId, startTime);

            JObject jsonObj = JObject.Parse(QueryData);
            ////获取json元素
            //IList<string> keys = jsonObj.Properties().Select(p => p.Name).ToList();
            //foreach (var item in keys )
            //{
            //    ShowLog("queryDevices Data: key->" + item);
            //}
            Runtime.ShowLog("queryDevices Data:" + jsonObj.ToString());

            int reslut = DataCollectionDAL.SaveData(buildID, jsonObj);
            Runtime.ShowLog("--------------------数据 存入数据库成功，总共：" + reslut + "条");

            Dictionary<string, string> dataDic = new Dictionary<string, string>();

            JArray jArray = JArray.Parse(jsonObj["deviceDataHistoryDTOs"].ToString());

            for (int i = 0; i < jArray.Count; i++)  //遍历JArray  
            {
                //转化为JObject
                JObject itemObj = JObject.Parse(jArray[i].ToString());
                Runtime.ShowLog("---------------------------------------");
                string deviceId2 = itemObj["deviceId"].ToString();
                string gatewayId = itemObj["gatewayId"].ToString();
                string totalPower = itemObj["data"]["totalPower"].ToString();
                string batteryVoltage = itemObj["data"]["batteryVoltage"].ToString();
                string color = itemObj["data"]["color"].ToString();
                string switchStatus = itemObj["data"]["switchStatus"].ToString();
                string timestamp = itemObj["timestamp"].ToString();
                Runtime.ShowLog("queryDevices Data deviceId:" + deviceId2);
                //ShowLog("queryDevices Data gatewayId:" + gatewayId);
                //ShowLog("queryDevices Data totalPower:" + totalPower);
                //ShowLog("queryDevices Data batteryVoltage:" + batteryVoltage);
                //ShowLog("queryDevices Data color:" + color);
                //ShowLog("queryDevices Data switchStatus:" + switchStatus);
                Runtime.ShowLog("queryDevices Data timestamp:" + timestamp);
                JObject itemObj2 = JObject.Parse(itemObj["data"].ToString());
                IList<string> datakeys2 = itemObj2.Properties().Select(p => p.Name).ToList();
                IList<string> dataValues2 = itemObj2.Properties().Select(p => p.Value.ToString()).ToList();
                for (int j = 0; j < datakeys2.Count; j++)
                {
                    Runtime.ShowLog("queryDevices Data: DataKey->" + datakeys2[j] + "  DataValue->" + dataValues2[j]);
                    //dataDic.Add(datakeys2[j], dataValues2[j]);
                }

                foreach (var item in dataDic)
                {
                    Runtime.ShowLog("queryDevices Data: DataKey->" + item.Key + "  DataValue->" + item.Value);

                }

                //foreach (var item in dataValues2)
                //{
                //    ShowLog("queryDevices Data: DataValue->" + item);
                //}
            }


        }

        private void btnGetDevices_Click(object sender, EventArgs e)
        {
            long pageNo = 0;
            long pageSize = 10;
            string QueryResult = DataCollection.QueryDevice(pageNo, pageSize);

            JObject jObj = JObject.Parse(QueryResult);
            QueryDevicesMode queryDevices = new QueryDevicesMode();
            string buildID = "10002000";
            queryDevices = Newtonsoft.Json.JsonConvert.DeserializeObject<QueryDevicesMode>(QueryResult);
            Runtime.ShowLog("queryDevices buildID:" + queryDevices.buildID);

            Runtime.ShowLog("queryDevices jObj:" + jObj.ToString());
            foreach (var item in queryDevices.devices)
            {
                Runtime.ShowLog("---------------------------------------");
                Runtime.ShowLog("queryDevices buildID:" + queryDevices.buildID);
                Runtime.ShowLog("queryDevices devicesID:" + item.deviceId);
                Runtime.ShowLog("queryDevices gatewayId:" + item.gatewayId);
                Runtime.ShowLog("queryDevices nodeType:" + item.nodeType);
                Runtime.ShowLog("queryDevices createTime:" + item.createTime);
                Runtime.ShowLog("queryDevices lastModifiedTime:" + item.lastModifiedTime);
                Runtime.ShowLog("queryDevices nodeId:" + item.deviceInfo.nodeId);
                Runtime.ShowLog("queryDevices Name:" + item.deviceInfo.name);
                Runtime.ShowLog("queryDevices ProtocolType:" + item.deviceInfo.protocolType);
                Runtime.ShowLog("queryDevices Status:" + item.deviceInfo.status);


            }
            int reslut = DataCollectionDAL.SaveDevices(buildID, queryDevices);
            Runtime.ShowLog("--------------------设备 存入数据库：" + reslut);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                Runtime.m_IsRunning = true;

                Thread GetNewTokenThread = new Thread(Authentication.getNewTokenFromAPI);
                GetNewTokenThread.Start();

                Thread DataCollectThread = new Thread(DataCollection.CollectFromAPI);
                DataCollectThread.Start();
                /*
                // 调用封装北向接口的功能 API
                if (!Authentication.Login())
                {
                    Runtime.ShowLog("！！！ 登录失败 ！！！");
                    LogHelper.log.Error("！！！ 登录失败 ！！！");

                }
                else
                {
                    LogHelper.log.Info("*** 登录成功 *** accessToken：" + Authentication.Auth.AccessToken);
                    Runtime.ShowLog("*** 登录成功 ***");

                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                    Runtime.m_IsRunning = true;
                }
               */

            }
            catch(Exception ex)
            {
                Runtime.ShowLog("！！！ 启动服务失败！！！  详细：" + ex.Message);
                LogHelper.log.Error("！！！ 启动服务失败！！！  详细：" + ex.Message);
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            Runtime.m_IsRunning = false;
            Runtime.m_IsRefreshToken = false;
        }
    }
}
