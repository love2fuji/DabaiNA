using DabaiNA.Common;
using DabaiNA.Modes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabaiNA.DAL
{
    class DataCollectionDAL
    {
        
        
        
        /// <summary>
        /// 查询平台中设备，并保存到数据库中
        /// </summary>
        /// <param name="queryDevicesMode">设备信息</param>
        /// <returns></returns>
        public static int SaveDevices(QueryDevicesMode queryDevicesMode)
        {
            int reslut = 0;
            foreach (var item in queryDevicesMode.devices)
            {

                //数据插入表：T_DC_DevicesInfo
                string SQLString = @"IF EXISTS (SELECT 1 FROM T_DC_DevicesInfo WHERE F_DeviceId= '" + item.deviceId + @"') 
                                            UPDATE T_DC_DevicesInfo SET F_GatewayId = '" + item.gatewayId + @"', F_NodeType = '" + item.nodeType +
                                                @"', F_LastModifiedTime = '" + item.lastModifiedTime + @"', F_NodeId = '" + item.deviceInfo.nodeId +
                                                @"', F_Description = '" + item.deviceInfo.description + @"', F_ManufacturerName = '" + item.deviceInfo.manufacturerName +
                                                @"', F_Mac = '" + item.deviceInfo.mac + @"', F_DeviceType = '" + item.deviceInfo.deviceType +
                                                @"', F_ProtocolType = '" + item.deviceInfo.protocolType + @"', F_Status = '" + item.deviceInfo.status +
                                                @"' WHERE F_DeviceId = '" + item.deviceId + @"'
                                        ELSE
                                            INSERT INTO T_DC_DevicesInfo
                                            (F_BuildID, F_DeviceId, F_GatewayId, F_NodeType, F_CreateTime, F_LastModifiedTime, F_NodeId, F_Name, 
                                             F_Description, F_ManufacturerId, F_ManufacturerName, F_Mac, F_DeviceType, F_Model, F_ProtocolType, F_Status  ) VALUES
                                               ( '10001000','" + item.deviceId + @"','" + item.gatewayId + @"','" + item.nodeType + @"','" + item.createTime +
                                               @"','" + item.lastModifiedTime + @"','" + item.deviceInfo.nodeId + @"','" + item.deviceInfo.name + @"','" + item.deviceInfo.description +
                                               @"','" + item.deviceInfo.manufacturerId + @"','" + item.deviceInfo.manufacturerName + @"','" + item.deviceInfo.mac + @"','" + item.deviceInfo.deviceType +
                                               @"','" + item.deviceInfo.model + @"','" + item.deviceInfo.protocolType + @"','" + item.deviceInfo.status +
                                               @"')";

                reslut = reslut + SQLHelper.ExecuteSql(SQLString);
            }
            return reslut;
        }

        /// <summary>
        /// 查询平台中设备，并保存到数据库中
        /// </summary>
        /// <param name="buildID">区域编码</param>
        /// <param name="queryDevicesMode">设备信息</param>
        /// <returns></returns>
        public static int SaveDevices(string buildID, QueryDevicesMode queryDevicesMode)
        {
            int reslut = 0;
            foreach (var item in queryDevicesMode.devices)
            {

                //数据插入表：T_DC_DevicesInfo
                string SQLString = @"IF EXISTS (SELECT 1 FROM T_DC_DevicesInfo WHERE F_DeviceId= '" + item.deviceId + @"') 
                                            UPDATE T_DC_DevicesInfo SET F_GatewayId = '" + item.gatewayId + @"', F_NodeType = '" + item.nodeType +
                                                @"', F_LastModifiedTime = '" + item.lastModifiedTime + @"', F_NodeId = '" + item.deviceInfo.nodeId +
                                                @"', F_Description = '" + item.deviceInfo.description + @"', F_ManufacturerName = '" + item.deviceInfo.manufacturerName +
                                                @"', F_Mac = '" + item.deviceInfo.mac + @"', F_DeviceType = '" + item.deviceInfo.deviceType +
                                                @"', F_ProtocolType = '" + item.deviceInfo.protocolType + @"', F_Status = '" + item.deviceInfo.status +
                                                @"' WHERE F_DeviceId = '" + item.deviceId + @"'
                                        ELSE
                                            INSERT INTO T_DC_DevicesInfo
                                            (F_BuildID, F_DeviceId, F_GatewayId, F_NodeType, F_CreateTime, F_LastModifiedTime, F_NodeId, F_Name, 
                                             F_Description, F_ManufacturerId, F_ManufacturerName, F_Mac, F_DeviceType, F_Model, F_ProtocolType, F_Status  ) VALUES
                                               ( '" + buildID + @"','" + item.deviceId + @"','" + item.gatewayId + @"','" + item.nodeType + @"','" + item.createTime +
                                               @"','" + item.lastModifiedTime + @"','" + item.deviceInfo.nodeId + @"','" + item.deviceInfo.name + @"','" + item.deviceInfo.description +
                                               @"','" + item.deviceInfo.manufacturerId + @"','" + item.deviceInfo.manufacturerName + @"','" + item.deviceInfo.mac + @"','" + item.deviceInfo.deviceType +
                                               @"','" + item.deviceInfo.model + @"','" + item.deviceInfo.protocolType + @"','" + item.deviceInfo.status +
                                               @"')";

                reslut = reslut + SQLHelper.ExecuteSql(SQLString);
            }
            return reslut;
        }


        /// <summary>
        /// 获取一个数据库中所以的设备ID
        /// </summary>
        /// <param name="buildID">区域编码</param>
        /// <returns></returns>
        public static List<string> GetDevices()
        {
            try
            {
                List<string> devicesList = new List<string>();
                //查询表：T_DC_DevicesInfo
                string SQLString = @"SELECT F_DeviceId FROM T_DC_DevicesInfo WHERE F_Status ='ONLINE' ORDER BY F_CreateTime DESC
                                    ";
                DataTable dataTable = SQLHelper.GetDataTable(SQLString);
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string device = Convert.ToString(row["F_DeviceId"]);
                        devicesList.Add(device);
                    }
                }
                return devicesList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 获取一个区域的设备
        /// </summary>
        /// <param name="buildID">区域编码</param>
        /// <returns></returns>
        public static List<string> GetDevices(string buildID)
        {
            try
            {
                List<string> devicesList = new List<string>();
                //查询表：T_DC_DevicesInfo
                string SQLString = @"SELECT F_DeviceId FROM T_DC_DevicesInfo WHERE F_BuildID='" + buildID + @"'
                                    ";
                DataTable dataTable = SQLHelper.GetDataTable(SQLString);
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string device = Convert.ToString(row["F_DeviceId"]);
                        devicesList.Add(device);
                    }
                }
                return devicesList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 获取一个的设备最后一次数据更新时间（UTC时间）
        /// </summary>
        /// <param name="deviceId">区域编码</param>
        /// <returns>
        /// 若设备没有最近的更新数据时间，则返回当前UTC时间
        /// </returns>
        public static string GetDeviceUpdataLastTime(string deviceId)
        {
            try
            {
                string utcString = string.Empty;
                //查询表：T_DC_DevicesInfo
                string SQLString = @"SELECT TOP 1 F_CalcTime FROM T_OV_MeterOrigValue WHERE F_DeviceId='" + deviceId + @"'
                                        ORDER BY F_CalcTime DESC
                                    ";
                DataTable dataTable = SQLHelper.GetDataTable(SQLString);
                if (dataTable.Rows.Count > 0)
                {
                    DateTime BJT = Convert.ToDateTime(dataTable.Rows[0][0]);
                    //TimeZone类表示时区，TimeZone.CurrentTimeZone方法：获取当前计算机的时区。
                    TimeZone tz = TimeZone.CurrentTimeZone;
                    //将当前计算机所在时区的时间(即:北京时间) 转换成UTC时间  
                    DateTime dtGMT = tz.ToUniversalTime(BJT);
                    dtGMT = dtGMT.AddSeconds(1);
                    return dtGMT.ToString("yyyyMMddTHHmmssZ");

                }
                else
                {
                    //若设备没有最近的更新数据时间，则返回当前UTC时间
                    DateTime utcNow = DateTime.UtcNow.AddDays(-7);
                    return utcNow.ToString("yyyyMMddTHHmmssZ");
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 设备数据保存至数据
        /// </summary>
        /// <param name="buildID">区域编码</param>
        /// <param name="jsonObj">JSON对象</param>
        /// <returns></returns>
        public static int SaveData(JObject jsonObj)
        {
            int reslut = 0;

            JArray jArray = JArray.Parse(jsonObj["deviceDataHistoryDTOs"].ToString());

            for (int i = 0; i < jArray.Count; i++)  //遍历JArray  
            {
                reslut++;
                //转化为JObject
                JObject itemObj = JObject.Parse(jArray[i].ToString());
                string deviceId = itemObj["deviceId"].ToString();
                string gatewayId = itemObj["gatewayId"].ToString();
                //string BatVoltage = itemObj["data"]["BatVoltage"].ToString();
                //string Temp = itemObj["data"]["Temp"].ToString();
                //string humidity = itemObj["data"]["humidity"].ToString();
                //string lightValue = itemObj["data"]["lightValue"].ToString();
                //string longitude = itemObj["data"]["longitude"].ToString();
                //string latitude = itemObj["data"]["latitude"].ToString();
                //string DI1 = itemObj["data"]["DI1"].ToString();
                //string DI2 = itemObj["data"]["DI2"].ToString();


                //将UTC时间 转换成 当前计算机所在时区的时间(即:北京时间)  
                DateTime timestamp = DateTime.ParseExact(itemObj["timestamp"].ToString(), "yyyyMMddTHHmmssZ",
                                     System.Globalization.CultureInfo.CurrentCulture);
                //string timestamp = dateISO8602.ToString("yyyy-MM-dd HH:mm:ss");

                JObject itemObj2 = JObject.Parse(itemObj["data"].ToString());
                IList<string> datakeys = itemObj2.Properties().Select(p => p.Name).ToList();
                IList<string> dataValues = itemObj2.Properties().Select(p => p.Value.ToString()).ToList();
                for (int j = 0; j < datakeys.Count; j++)
                {
                    //Console.WriteLine("queryDevices Data: DataKey->" + datakeys[j] + "  DataValue->" + dataValues[j]);
                    //数据插入表：T_OV_MeterOrigValue
                    string SQLString = @"IF EXISTS (SELECT 1 FROM T_OV_MeterOrigValue WHERE F_DeviceId= '" + deviceId +
                                                            @"' AND F_TagName='" + datakeys[j] +
                                                            @"' AND F_CalcTime='" + timestamp +
                                                    @"') 
                                                UPDATE T_OV_MeterOrigValue SET F_Value = '" + dataValues[j] + @"', F_UpdataTime = CONVERT(varchar(20), GETDATE(), 120)" +
                                                        @" WHERE F_DeviceId = '" + deviceId +
                                                        @"' AND F_TagName='" + datakeys[j] +
                                                        @"' AND F_CalcTime='" + timestamp +
                                                        @"' 
                                            ELSE
                                                INSERT INTO T_OV_MeterOrigValue
                                                (F_DeviceId, F_TagName, F_Value, F_CalcTime, F_UpdataTime ) VALUES
                                                   ( '" + deviceId + @"','" + datakeys[j] + @"','" + dataValues[j] + @"','" + timestamp +
                                                   @"', CONVERT(varchar(20), GETDATE(), 120)" +
                                                   @")";

                    SQLHelper.ExecuteSql(SQLString);
                }
            }

            return reslut;
        }

        /// <summary>
        /// 设备数据保存至数据
        /// </summary>
        /// <param name="buildID">区域编码</param>
        /// <param name="jsonObj">JSON对象</param>
        /// <returns></returns>
        public static int SaveData(string buildID, JObject jsonObj)
        {
            int reslut = 0;

            JArray jArray = JArray.Parse(jsonObj["deviceDataHistoryDTOs"].ToString());

            for (int i = 0; i < jArray.Count; i++)  //遍历JArray  
            {
                //转化为JObject
                JObject itemObj = JObject.Parse(jArray[i].ToString());
                string deviceId = itemObj["deviceId"].ToString();
                string gatewayId = itemObj["gatewayId"].ToString();
                //string totalPower = itemObj["data"]["totalPower"].ToString();
                //string batteryVoltage = itemObj["data"]["batteryVoltage"].ToString();
                //string color = itemObj["data"]["color"].ToString();
                //string switchStatus = itemObj["data"]["switchStatus"].ToString();
                //将UTC时间 转换成 当前计算机所在时区的时间(即:北京时间)  
                DateTime timestamp = DateTime.ParseExact(itemObj["timestamp"].ToString(), "yyyyMMddTHHmmssZ",
                               System.Globalization.CultureInfo.CurrentCulture);
                //string timestamp = dateISO8602.ToString("yyyy-MM-dd HH:mm:ss");

                JObject itemObj2 = JObject.Parse(itemObj["data"].ToString());
                IList<string> datakeys = itemObj2.Properties().Select(p => p.Name).ToList();
                IList<string> dataValues = itemObj2.Properties().Select(p => p.Value.ToString()).ToList();
                for (int j = 0; j < datakeys.Count; j++)
                {
                    Console.WriteLine("queryDevices Data: DataKey->" + datakeys[j] + "  DataValue->" + dataValues[j]);
                    //数据插入表：T_OV_MeterOrigValue
                    string SQLString = @"IF EXISTS (SELECT 1 FROM T_OV_MeterOrigValue WHERE F_DeviceId= '" + deviceId +
                                                            @"' AND F_BuildID='" + buildID +
                                                            @"' AND F_TagName='" + datakeys[j] +
                                                            @"' AND F_CalcTime='" + timestamp +
                                                    @"') 
                                                UPDATE T_OV_MeterOrigValue SET F_Value = '" + dataValues[j] + @"', F_UpdataTime = CONVERT(varchar(20), GETDATE(), 120)" +
                                                        @" WHERE F_DeviceId = '" + deviceId +
                                                        @"' AND F_BuildID='" + buildID +
                                                        @"' AND F_TagName='" + datakeys[j] +
                                                        @"' AND F_CalcTime='" + timestamp +
                                                        @"' 
                                            ELSE
                                                INSERT INTO T_OV_MeterOrigValue
                                                (F_BuildID, F_DeviceId, F_GatewayId, F_TagName, F_Value, F_CalcTime, F_UpdataTime ) VALUES
                                                   ( '" + buildID + @"','" + deviceId + @"','" + gatewayId + @"','" + datakeys[j] + @"','" + dataValues[j] + @"','" + timestamp +
                                                   @"', CONVERT(varchar(20), GETDATE(), 120)" +
                                                   @")";

                    reslut = reslut + SQLHelper.ExecuteSql(SQLString);
                }
            }

            return reslut;
        }

    }
}
