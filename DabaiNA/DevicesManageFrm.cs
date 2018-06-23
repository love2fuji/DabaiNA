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
        DataTable deleteDeviceInfo = new DataTable();

        private bool comboxFirstLoad = true;
        private bool comboxFirstLoad2 = true;
        private DevicesMode device = new DevicesMode();

        public DevicesManageFrm()
        {
            InitializeComponent();

            AddData2Combox();
        }

        private void DevicesManageFrm_Load(object sender, EventArgs e)
        {
            textBoxBuildID.Text = cboxBiuldInfo.GetItemText(cboxBiuldInfo.SelectedValue);

            btnModifyDevice.Enabled = false;
            btnDeleteDevice.Enabled = false;

        }

        private void AddData2Combox()
        {
            //注册设备
            BuildInfo = DeviceManageDAL.GetBuildInfo();
            cboxBiuldInfo.DataSource = BuildInfo;
            cboxBiuldInfo.DisplayMember = BuildInfo.Columns[1].ColumnName;
            cboxBiuldInfo.ValueMember = BuildInfo.Columns[0].ColumnName;

            //修改设备
            cboxBiuldInfo2.DataSource = BuildInfo;
            cboxBiuldInfo2.DisplayMember = "F_BuildName";
            cboxBiuldInfo2.ValueMember = "F_BuildID";
            //删除设备
            //cboxDeleteBiuldInfo.DataSource = BuildInfo;
            //cboxDeleteBiuldInfo.DisplayMember = "F_BuildName";
            //cboxDeleteBiuldInfo.ValueMember = "F_BuildID";


        }



        /// <summary>
        /// 注册直连设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            catch (Exception ex)
            {
                Runtime.ShowLog("！！！ 注册设备 失败！！！  详细：" + ex.Message);
                LogHelper.log.Error("！！！ 注册设备 失败！！！  详细：" + ex.Message);
            }
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


        /// <summary>
        /// 修改设备信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyDevice_Click(object sender, EventArgs e)
        {
            //修改设备信息
            try
            {
                ModifyDeviceInfoMode modifyDevice = new ModifyDeviceInfoMode();

                string buildID2 = cboxBiuldInfo2.GetItemText(cboxBiuldInfo2.SelectedValue);
                string deviceId = cboxDeviceID2.GetItemText(cboxDeviceID2.SelectedValue);
                string deviceName = textBoxDeviceName2.Text;
                string deviceNodeId = cboxDeviceID2.GetItemText(cboxDeviceID2.Items[cboxDeviceID2.SelectedIndex]);
                string manufacturerId = textBoxManufacturerId.Text;
                string manufacturerName = textBoxManufacturerName.Text;
                string deviceType = textBoxDeviceType.Text;
                string model = textBoxModel.Text;
                string protocolType = textBoxProtocolType.Text;

                modifyDevice.name = textBoxDeviceName2.Text;
                modifyDevice.manufacturerId = textBoxManufacturerId.Text;
                modifyDevice.manufacturerName = textBoxManufacturerName.Text;
                modifyDevice.deviceType = textBoxDeviceType.Text;
                modifyDevice.model = textBoxModel.Text;
                modifyDevice.protocolType = textBoxProtocolType.Text;

                string Result = DevicesManageServer.ModifyDeviceInfo(deviceId, modifyDevice);

                Runtime.ShowLog("修改 设备 成功：" + Result);
                Runtime.ShowLog("请求响应的状态码：" + AuthenticationServer.httpStatusCode);
                MessageBox.Show("修改 设备 成功 " + Result, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                Runtime.ShowLog("！！！ 修改 设备 失败！！！  详细：" + ex.Message);
                LogHelper.log.Error("！！！ 修改 设备 失败！！！  详细：" + ex.Message);
                MessageBox.Show("！！！ 修改 设备 失败！！！  详细：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboxDeviceID2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string deviceName = cboxDeviceID2.GetItemText(cboxDeviceID2.Items[cboxDeviceID2.SelectedIndex]);
            string deviceID = cboxDeviceID2.GetItemText(cboxDeviceID2.SelectedValue);
            textBoxDeviceName2.Text = deviceName;
            Runtime.ShowLog(string.Format("修改设备 -> 设备名称 ：{0} , 设备ID：{1}", deviceName, deviceID));
        }

        private void cboxBiuldInfo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboxFirstLoad2)
            {
                comboxFirstLoad2 = false;
                return;
            }
            string buildName2 = cboxBiuldInfo2.GetItemText(cboxBiuldInfo2.Items[cboxBiuldInfo2.SelectedIndex]);
            string buildID2 = cboxBiuldInfo2.GetItemText(cboxBiuldInfo2.SelectedValue);

            //获取设备列表，并显示
            DataTable DeviceInfo = new DataTable();
            DeviceInfo = DeviceManageDAL.GetDeviceInfo(buildID2);
            cboxDeviceID2.DataSource = DeviceInfo;
            cboxDeviceID2.DisplayMember = DeviceInfo.Columns[1].ColumnName;
            cboxDeviceID2.ValueMember = DeviceInfo.Columns[0].ColumnName;
            //获取修改设备的模板信息
            DataTable DeviceModify = new DataTable();
            DeviceModify = DeviceManageDAL.GetDeviceModifyInfo(buildID2);

            if (DeviceModify == null || DeviceModify.Rows.Count == 0)
            {
                btnModifyDevice.Enabled = false;
                MessageBox.Show("所选择区域没有绑定服务器，暂时无法使用，请选择正确的区域", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBoxManufacturerId.Text = DeviceModify.Rows[0]["F_ManufacturerId"].ToString();
                textBoxManufacturerName.Text = DeviceModify.Rows[0]["F_ManufacturerName"].ToString();
                textBoxDeviceType.Text = DeviceModify.Rows[0]["F_DeviceType"].ToString();
                textBoxModel.Text = DeviceModify.Rows[0]["F_Model"].ToString();
                textBoxProtocolType.Text = DeviceModify.Rows[0]["F_ProtocolType"].ToString();
                Runtime.ShowLog("选择修改设备 所所区域为：" + buildName2 + "  区域代码：" + buildID2);
                btnModifyDevice.Enabled = true;
            }
        }


        /// <summary>
        /// 删除设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteDevice_Click(object sender, EventArgs e)
        {
            try
            {
                string deviceID = comboBoxDeleteDevice.GetItemText(comboBoxDeleteDevice.SelectedValue);

                if (deviceID.Length >= 36)
                {
                    string reslut = DevicesManageServer.DeleteDirectlyConnectedDevice(deviceID);
                    if (string.IsNullOrEmpty(reslut))
                    {
                        Runtime.ShowLog("删除设备成功：");

                    }

                    int deviceNumber = DeviceManageDAL.DeleteOneDevice(deviceID);
                    Runtime.ShowLog("删除" + deviceNumber + "设备");
                }
            }
            catch (Exception ex)
            {
                Runtime.ShowLog("！！！删除设备失败 ！！！ 详细："+ ex.Message);
            }
        }

        private void cboxDeleteBiuldInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboxFirstLoad)
            {
                comboxFirstLoad = false;
                return;
            }
            string buildID = cboxDeleteBiuldInfo.GetItemText(cboxDeleteBiuldInfo.SelectedValue);
            string buildName = cboxDeleteBiuldInfo.GetItemText(cboxDeleteBiuldInfo.Items[cboxBiuldInfo.SelectedIndex]);

            deleteDeviceInfo = DeviceManageDAL.GetDeviceInfo(buildID);
            if (deleteDeviceInfo == null || deleteDeviceInfo.Rows.Count == 0)
            {
                btnDeleteDevice.Enabled = false;
                MessageBox.Show("所选择区域没有绑定服务器，暂时无法使用，请选择正确的区域", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                comboBoxDeleteDevice.DataSource = deleteDeviceInfo;
                comboBoxDeleteDevice.DisplayMember = deleteDeviceInfo.Columns[1].ColumnName;
                comboBoxDeleteDevice.ValueMember = deleteDeviceInfo.Columns[0].ColumnName;

                Runtime.ShowLog("选择修改设备 所所区域为：" + buildName + "  区域代码：" + buildID);
                btnDeleteDevice.Enabled = true;
            }
        }

        private void comboBoxDeleteDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            string deviceID = comboBoxDeleteDevice.GetItemText(comboBoxDeleteDevice.SelectedValue);
            //DataRow[] drs = deleteDeviceInfo.Select("F_DeviceId = '"+deviceID+"'");

            if (deviceID.Length >= 36)
            {
                textBoxDeleteDeviceName.Text = DeviceManageDAL.GetDeviceName(deviceID);
            }
        }

        private void cboxDeleteBiuldInfo_Click(object sender, EventArgs e)
        {
            comboxFirstLoad = true;
            //获取区域列表
            cboxDeleteBiuldInfo.DataSource = DeviceManageDAL.GetBuildInfo();
            cboxDeleteBiuldInfo.DisplayMember = "F_BuildName";
            cboxDeleteBiuldInfo.ValueMember = "F_BuildID";

            string buildID = cboxDeleteBiuldInfo.GetItemText(cboxDeleteBiuldInfo.SelectedValue);
            string buildName = cboxDeleteBiuldInfo.GetItemText(cboxDeleteBiuldInfo.Items[cboxBiuldInfo.SelectedIndex]);

            //获取设备列表，并显示

            DataTable DeviceInfo = new DataTable();
            DeviceInfo = DeviceManageDAL.GetDeviceInfo(buildID);
            if (DeviceInfo == null || DeviceInfo.Rows.Count == 0)
            {
                btnDeleteDevice.Enabled = false;
                MessageBox.Show("所选择区域当前没有设备，请选择正确的区域", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                comboBoxDeleteDevice.DataSource = DeviceInfo;
                comboBoxDeleteDevice.DisplayMember = DeviceInfo.Columns[1].ColumnName;
                comboBoxDeleteDevice.ValueMember = DeviceInfo.Columns[0].ColumnName;
                Runtime.ShowLog("选择修改设备 所所区域为：" + buildName + "  区域代码：" + buildID);
                btnDeleteDevice.Enabled = true;
            }


        }
    }
}
