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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DabaiNA
{
    public partial class Main : Form
    {
        private static DevicesMode device = new DevicesMode();

        internal static DevicesMode Device { get => device; set => device = value; }

        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示软件运行日志
        /// </summary>
        /// <param name="info"></param>
        private delegate void ShowLogEventHandler(string info);
        public void ShowLog(string info)
        {
            if (this.ServerLog.InvokeRequired)
            {
                ShowLogEventHandler showLogHandler = new ShowLogEventHandler(this.ShowLog);
                this.ServerLog.BeginInvoke(showLogHandler, info);
            }
            else
            {
                string s = "";
                for (int i = 0; i < this.ServerLog.Lines.Length; i++)
                {
                    if (i > 200)
                        break;
                    s += ("\r\n" + this.ServerLog.Lines[i]);
                }
                this.ServerLog.Text = (DateTime.Now.ToString("yyy-MM-dd HH:mm:ss") + " >>>  " + info + s);
            }
        }


        private void Main_Load(object sender, EventArgs e)
        {
            // 调用封装北向接口的功能 API
            if (! Authentication.Login())
                return;
            ShowLog(Authentication.NorthAccessToken);
            ShowLog("scope="+Authentication.Auth.Scope +
                    "  tokenType=" + Authentication.Auth.TokenType +
                    "  expiresIn=" + Authentication.Auth.ExpiresIn +
                    "  accessToken="+Authentication.Auth.AccessToken);

            //if (!Authentication.RefreshToken())
            //    return;
            //ShowLog(Authentication.NorthAccessToken);
           

        }

        private void btnRegisterDevice_Click(object sender, EventArgs e)
        {
            //注册直连设备
            string nodeId = "SH_Door_201805112145";
            string registerResult = DevicesManage.RegisterDirectlyConnectedDevice(nodeId);
            device = Newtonsoft.Json.JsonConvert.DeserializeObject<DevicesMode>(registerResult);
            ShowLog("注册成功："+registerResult);
            ShowLog("请求响应的状态码：" + Authentication.httpStatusCode);

            Console.WriteLine("注册成功，设备ID："+device.deviceId);
        }

        private void btnQueryDeviceStatus_Click(object sender, EventArgs e)
        {
            //查询设备激活状态
            string deviceId = "49cf5244-8fe4-430d-950a-cdc6a2b13eb5";
            string deviceStatus = DevicesManage.QueryDeviceActivationStatus(deviceId);

            ShowLog(deviceStatus);
            ShowLog("请求响应的状态码：" + Authentication.httpStatusCode);
        }

        private void btnDeleteDevice_Click(object sender, EventArgs e)
        {
            //删除设备
            string deviceId = "49cf5244-8fe4-430d-950a-cdc6a2b13eb5";
            string deleteResult = DevicesManage.DeleteDirectlyConnectedDevice(deviceId);
            ShowLog(deleteResult);
            ShowLog("请求响应的状态码：" + Authentication.httpStatusCode);
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

            string deviceId = "a823fc09-e119-4caa-af1b-f7f3f0eb4593";
            string startTime = "20180521T134000Z";
            string endTime = "20180522T224044Z";
            string QueryData=DataCollection.QueryDeviceData(deviceId);
            ShowLog("queryDevices Data:" + QueryData);

            string QueryData2 = DataCollection.QueryDeviceHistoryData(deviceId, deviceId, startTime, endTime);
            ShowLog("queryDevices Data:" + QueryData2);


        }

        private void btnGetDevices_Click(object sender, EventArgs e)
        {
            long pageNo = 0;
            long pageSize = 10;
            string QueryResult = DataCollection.QueryDevice(pageNo, pageSize);

            JObject jObj = JObject.Parse(QueryResult);
            QueryDevicesMode queryDevices = new QueryDevicesMode();
            queryDevices = Newtonsoft.Json.JsonConvert.DeserializeObject<QueryDevicesMode>(QueryResult);


            ShowLog("queryDevices jObj:" + jObj.ToString());
            //ShowLog("queryDevices devices:" + queryDevices.devices.First().deviceId);
            ShowLog("queryDevices totalCount:" + queryDevices.totalCount);
            foreach (var item in queryDevices.devices)
            {
                ShowLog("---------------------------------------");
                ShowLog("queryDevices devicesID:" + item.deviceId);
                ShowLog("queryDevices gatewayId:" + item.gatewayId);
                ShowLog("queryDevices nodeType:" + item.nodeType);
                ShowLog("queryDevices createTime:" + item.createTime);
                ShowLog("queryDevices lastModifiedTime:" + item.lastModifiedTime);
                ShowLog("queryDevices nodeId:" + item.deviceInfo.nodeId);
                ShowLog("queryDevices Name:" + item.deviceInfo.name);
                ShowLog("queryDevices ProtocolType:" + item.deviceInfo.protocolType);
                ShowLog("queryDevices Status:" + item.deviceInfo.status);
            }
        }
    }
}
