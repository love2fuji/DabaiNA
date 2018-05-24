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
            string deviceId = "a823fc09-e119-4caa-af1b-f7f3f0eb4593";
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

            //查询一个设备历史数据
            string deviceId = "a823fc09-e119-4caa-af1b-f7f3f0eb4593";
            string startTime = "20180521T134000Z";
            string endTime = "20180522T224044Z";

            string buildID = "10002000";

            string QueryData = DataCollection.QueryDeviceHistoryData(deviceId, deviceId, startTime);
            ShowLog("queryDevices Data:" + QueryData);

            JObject jsonObj = JObject.Parse(QueryData);
            ////获取json元素
            //IList<string> keys = jsonObj.Properties().Select(p => p.Name).ToList();
            //foreach (var item in keys )
            //{
            //    ShowLog("queryDevices Data: key->" + item);
            //}
            //ShowLog("queryDevices Data:" + jsonObj.ToString());

            int reslut = DataCollectionDAL.SaveData(buildID, jsonObj);
            ShowLog("--------------------数据 存入数据库成功，总共：" + reslut+"条");

            Dictionary<string, string> dataDic = new Dictionary<string, string>();

            JArray jArray = JArray.Parse(jsonObj["deviceDataHistoryDTOs"].ToString());

            for (int i = 0; i < jArray.Count; i++)  //遍历JArray  
            {
                //转化为JObject
                JObject itemObj = JObject.Parse(jArray[i].ToString());
                ShowLog("---------------------------------------");
                string deviceId2 = itemObj["deviceId"].ToString();
                string gatewayId = itemObj["gatewayId"].ToString();
                string totalPower = itemObj["data"]["totalPower"].ToString();
                string batteryVoltage = itemObj["data"]["batteryVoltage"].ToString();
                string color = itemObj["data"]["color"].ToString();
                string switchStatus = itemObj["data"]["switchStatus"].ToString();
                string timestamp = itemObj["timestamp"].ToString();
                ShowLog("queryDevices Data deviceId:" + deviceId2);
                //ShowLog("queryDevices Data gatewayId:" + gatewayId);
                //ShowLog("queryDevices Data totalPower:" + totalPower);
                //ShowLog("queryDevices Data batteryVoltage:" + batteryVoltage);
                //ShowLog("queryDevices Data color:" + color);
                //ShowLog("queryDevices Data switchStatus:" + switchStatus);
                ShowLog("queryDevices Data timestamp:" + timestamp);
                JObject itemObj2 = JObject.Parse(itemObj["data"].ToString());
                IList<string> datakeys2 = itemObj2.Properties().Select(p => p.Name).ToList();
                IList<string> dataValues2 = itemObj2.Properties().Select(p => p.Value.ToString()).ToList();
                for (int j=0;j< datakeys2.Count;j++)
                {
                    ShowLog("queryDevices Data: DataKey->" + datakeys2[j] + "  DataValue->" + dataValues2[j]);
                    //dataDic.Add(datakeys2[j], dataValues2[j]);
                }

                foreach (var item in dataDic)
                {
                    ShowLog("queryDevices Data: DataKey->" + item.Key + "  DataValue->"+ item.Value);

                }

                //foreach (var item in dataValues2)
                //{
                //    ShowLog("queryDevices Data: DataValue->" + item);
                //}
            }

                ShowLog("queryDevices Data:" + jsonObj["deviceDataHistoryDTOs"][0]["data"]);
            //ShowLog("queryDevices Data:" + jObj);
            ShowLog("queryDevices Data:" + jsonObj["gatewayId"]);
            //ShowLog("queryDevices Data:" + jObj["deviceDataHistoryDTOs"]["data"]);
            //ShowLog("queryDevices Data--totalPower:" + jObj["deviceDataHistoryDTOs"]["data"]["totalPower"]);

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
            ShowLog("queryDevices buildID:" + queryDevices.buildID);

            ShowLog("queryDevices jObj:" + jObj.ToString());
            foreach (var item in queryDevices.devices)
            {
                ShowLog("---------------------------------------");
                ShowLog("queryDevices buildID:" + queryDevices.buildID);
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
            int reslut = DataCollectionDAL.SaveDevices(buildID, queryDevices);
            ShowLog("--------------------设备 存入数据库：" + reslut);
        }
    }
}
