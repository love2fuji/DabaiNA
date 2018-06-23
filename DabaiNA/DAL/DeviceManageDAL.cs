using DabaiNA.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabaiNA.DAL
{
    class DeviceManageDAL
    {

        public static DataTable GetBuildInfo()
        {
            string SQLString = @"SELECT  F_BuildID,F_BuildName
                                FROM T_BD_BuildBaseInfo";

            DataTable dt = SQLHelper.GetDataTable(SQLString);
            return dt;
        }
        /// <summary>
        /// 获取指定区域内的所有设备
        /// </summary>
        /// <param name="buildID"></param>
        /// <returns></returns>
        public static DataTable GetDeviceInfo(string buildID )
        {
            string SQLString = @"SELECT  F_DeviceId,F_NodeId ,F_Name FROM T_DC_DevicesInfo WHERE  F_BuildID= '" + buildID+@"'";

            DataTable dt = SQLHelper.GetDataTable(SQLString);
            return dt;
        }

        /// <summary>
        /// 根据设备ID获取设备名称
        /// </summary>
        /// <param name="deviceID"></param>
        /// <returns></returns>
        public static string GetDeviceName(string deviceID)
        {
            string deviceName=string.Empty;
            string SQLString = @"SELECT  F_Name FROM T_DC_DevicesInfo WHERE  F_DeviceId= '" + deviceID + @"'";
            
            DataTable table = SQLHelper.GetDataTable(SQLString);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    deviceName = Convert.ToString( row["F_Name"]);
                }
            }
            return deviceName;
        }


        public static DataTable GetDeviceModifyInfo(string buildID)
        {
            string SQLString = @"SELECT TOP 1 F_ManufacturerId,F_ManufacturerName,F_DeviceType,F_Model,F_ProtocolType  FROM T_DC_DevicesInfo WHERE  F_BuildID= '" + buildID + @"' AND F_Status='ONLINE'";

            DataTable dt = SQLHelper.GetDataTable(SQLString);
            return dt;
        }

        public static int DeleteOneDevice(string deviceID)
        {
            
            string SQLString = @"DELETE FROM T_DC_DevicesInfo WHERE  F_DeviceId= '" + deviceID + @"'";

              int result = SQLHelper.ExecuteSql(SQLString);
           
            return result;
        }
    }
}
