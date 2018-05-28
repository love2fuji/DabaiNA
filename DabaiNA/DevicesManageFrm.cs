using DabaiNA.Common;
using DabaiNA.DAL;
using DabaiNA.HWAuthentication;
using DabaiNA.Modes;
using DabaiNA.NAServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DabaiNA
{
    public partial class DevicesManageFrm : Form
    {

        private DataTable BuildInfo = new DataTable();
        private bool comboxFirstLoad = true;
        private DevicesMode device = new DevicesMode();

        public DevicesManageFrm()
        {
            InitializeComponent();
            AddData2Combox();
        }

        private void DevicesManageFrm_Load(object sender, EventArgs e)
        {
            textBoxBuildID.Text = cboxBiuldInfo.GetItemText(cboxBiuldInfo.SelectedValue); 
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
            textBoxBuildID.Text = buildID;

            Runtime.ShowLog("选择区域为：" + buildName + "  区域代码：" + buildID);
        }

        private void btnRegisterDevice_Click(object sender, EventArgs e)
        {
            //注册直连设备
            try
            {
                
                string buildName = cboxBiuldInfo.GetItemText(cboxBiuldInfo.Items[cboxBiuldInfo.SelectedIndex]);
                string buildID = textBoxBuildID.Text;
                string deviceName = textBoxDeviceName.Text;
                string deviceNodeId = textBoxDeviceNodeId.Text;
                string devicePSK = textBoxDevicePSK.Text;
                string registerResult = DevicesManageServer.RegisterDirectlyConnectedDevice(deviceNodeId, devicePSK);
                device = Newtonsoft.Json.JsonConvert.DeserializeObject<DevicesMode>(registerResult);
                Runtime.ShowLog("注册成功：" + registerResult);
                Runtime.ShowLog("请求响应的状态码：" + AuthenticationServer.httpStatusCode);
            }
            catch(Exception ex)
            {
                Runtime.ShowLog("！！！ 注册设备 失败！！！  详细：" + ex.Message);
                LogHelper.log.Error("！！！ 注册设备 失败！！！  详细：" + ex.Message);
            }
        }
    }
}
