using DabaiNA.HWAuthentication;
using DabaiNA.Modes;
using DabaiNA.NAServer;
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
           
            //查询设备激活状态
            //string deviceStatus = DevicesManage.QueryDeviceActivationStatus(device.deviceId);
            //ShowLog(deviceStatus);

            //string deleteResult = DevicesManage.DeleteDirectlyConnectedDevice(device.deviceId);
            //ShowLog(deleteResult);
            //string lContent = Authentication.GetNorthAPIContent("sec/v1.1.0/login", "POST", "2");

        }

        private void btnRegisterDevice_Click(object sender, EventArgs e)
        {
            //注册直连设备
            string nodeId = "SH_Door_201805112145";
            string registerResult = DevicesManage.RegisterDirectlyConnectedDevice(nodeId);
            device = Newtonsoft.Json.JsonConvert.DeserializeObject<DevicesMode>(registerResult);
            ShowLog("注册成功："+registerResult);
            Console.WriteLine("注册成功，设备ID："+device.deviceId);
        }

        private void btnQueryDeviceStatus_Click(object sender, EventArgs e)
        {
            //查询设备激活状态
            string deviceId = "49cf5244-8fe4-430d-950a-cdc6a2b13eb5";
            string deviceStatus = DevicesManage.QueryDeviceActivationStatus(deviceId);

            ShowLog(deviceStatus);
        }

        private void btnDeleteDevice_Click(object sender, EventArgs e)
        {
            //删除设备
            string deviceId = "49cf5244-8fe4-430d-950a-cdc6a2b13eb5";
            string deleteResult = DevicesManage.DeleteDirectlyConnectedDevice(deviceId);
            ShowLog(deleteResult);
        }

        private void btnModifyDeviceInfo_Click(object sender, EventArgs e)
        {
            //修改设备信息
            //string deviceId = "49cf5244-8fe4-430d-950a-cdc6a2b13eb5";
            ModifyDeviceInfoMode modifyDeviceInfoMode = new ModifyDeviceInfoMode();

            string deleteResult = DevicesManage.ModifyDeviceInfo(device.deviceId, modifyDeviceInfoMode);
            ShowLog(deleteResult);
        }
    }
}
