using DabaiNA.Common;
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
            AddData2Combox();
        }
        //日志记录的事件委托声明
        private delegate void ShowLogEventHandler(string info);

        private static DevicesMode device = new DevicesMode();
        private bool comboxFirstLoad=true;
        DataTable BuildInfo = new DataTable();

        internal static DevicesMode Device { get => device; set => device = value; }

        private void Main_Load(object sender, EventArgs e)
        {
            Runtime.ServerLog = this.ServerLog;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            Runtime.m_IsRunning = false;
           

            

        }

        private void btnRegisterDevice_Click(object sender, EventArgs e)
        {
            

            Console.WriteLine("注册成功，设备ID：" + device.deviceId);
        }

        private void btnQueryDeviceStatus_Click(object sender, EventArgs e)
        {
            //查询设备激活状态
            string deviceId = "a823fc09-e119-4caa-af1b-f7f3f0eb4593";
            string deviceStatus = DevicesManageServer.QueryDeviceActivationStatus(deviceId);

            Runtime.ShowLog(deviceStatus);
            Runtime.ShowLog("请求响应的状态码：" + AuthenticationServer.httpStatusCode);
        }

        private void btnDeleteDevice_Click(object sender, EventArgs e)
        {
        }

        private void btnModifyDeviceInfo_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 查询当前平台中的设备，并保持至数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetDevices_Click(object sender, EventArgs e)
        {
            try
            {
                // 调用封装北向接口的功能 API
                if (!AuthenticationServer.Login())
                {
                    Runtime.ShowLog("！！！ 登录失败 ！！！");
                    LogHelper.log.Error("！！！ 登录失败 ！！！");
                }
                else
                {
                    LogHelper.log.Info("*** 登录成功 *** accessToken：" + AuthenticationServer.Auth.AccessToken);
                    Runtime.ShowLog("*** 登录成功 ***");
                }
                string buildName = cboxBiuldInfo.GetItemText(cboxBiuldInfo.Items[cboxBiuldInfo.SelectedIndex]);
                string buildID = cboxBiuldInfo.GetItemText(cboxBiuldInfo.SelectedValue);
                Runtime.ShowLog("选择区域为：" + buildName + "  区域代码：" + buildID);

                long pageNo = 0;
                long pageSize = 10;
                string QueryResult = DataCollectionServer.QueryDevice(pageNo, pageSize);

                JObject jObj = JObject.Parse(QueryResult);
                QueryDevicesMode queryDevices = new QueryDevicesMode();
                //string buildID = "10002000";
                queryDevices = Newtonsoft.Json.JsonConvert.DeserializeObject<QueryDevicesMode>(QueryResult);
                LogHelper.log.Info("查询当前平台中设备返回内容:" + jObj.ToString());
                Runtime.ShowLog("查询当前平台中设备:" + jObj.ToString());
                if (queryDevices.totalCount > 0)
                {
                    int reslut = DataCollectionDAL.SaveDevices(buildID, queryDevices);
                    LogHelper.log.Info(" 查询到的设备 存入数据库，总共：" + reslut + "设备");
                    Runtime.ShowLog(" 查询到的设备 存入数据库，总共：" + reslut + "设备");
                }
               

            }
            catch (Exception ex)
            {
                Runtime.ShowLog("！！！ 查询 失败！！！  详细：" + ex.Message);
                LogHelper.log.Error("！！！ 查询 失败！！！  详细：" + ex.Message);
            }
           
            
        }




        /// <summary>
        /// 启动服务 定时查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                Runtime.m_IsRunning = true;
                Runtime.m_IsRefreshToken = true;

                Thread GetNewTokenThread = new Thread(AuthenticationServer.getNewTokenFromAPI);
                GetNewTokenThread.Start();

                Thread DataCollectThread = new Thread(DataCollectionServer.DataCollectFromAPI);
                DataCollectThread.Start();
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


        private void AddData2Combox()
        {
            BuildInfo = DeviceManageDAL.GetBuildInfo();
            cboxBiuldInfo.DataSource = BuildInfo;
            cboxBiuldInfo.DisplayMember = BuildInfo.Columns[1].ColumnName;
            cboxBiuldInfo.ValueMember = BuildInfo.Columns[0].ColumnName;

        }

        private void cboxBiuldInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboxFirstLoad)
            {
                comboxFirstLoad = false;
                return;
            }
            string buildName = cboxBiuldInfo.GetItemText(cboxBiuldInfo.Items[cboxBiuldInfo.SelectedIndex]);
            string buildID = cboxBiuldInfo.GetItemText(cboxBiuldInfo.SelectedValue);

            Runtime.ShowLog("选择区域为：" + buildName + "  区域代码：" + buildID);
        }

        private void btnDeviceManage_Click(object sender, EventArgs e)
        {
            this.btnDeviceManage.Enabled = false;
            if ((new DevicesManageFrm()).ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("数据中心配置保存成功！", "确认", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                this.btnDeviceManage.Enabled = true;
            }
        }
    }
}
