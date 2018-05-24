using DabaiNA.Common;
using DabaiNA.Modes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
        /// <param name="queryDevicesMode"></param>
        /// <returns></returns>
        public static int SaveDevices(string buildID,QueryDevicesMode queryDevicesMode)
        {
            int reslut = 0;
            foreach (var item in queryDevicesMode.devices)
            {

                //数据插入表：T_DC_DevicesInfo
                string SQLString = @"IF EXISTS (SELECT 1 FROM T_DC_DevicesInfo WHERE F_DeviceId= '" + item.deviceId + @"'
                                                            AND F_BuildID='" + buildID + @"') 
                                            UPDATE T_DC_DevicesInfo SET F_GatewayId = '" + item.gatewayId + @"', F_Name = '" + item.deviceInfo.name +
                                                @"', F_NodeType = '" + item.nodeType +
                                                @"', F_LastModifiedTime = '" +item.lastModifiedTime + @"', F_NodeId = '" + item.deviceInfo.nodeId +
                                                @"', F_Description = '" + item.deviceInfo.description + @"', F_ManufacturerName = '" + item.deviceInfo.manufacturerName +
                                                @"', F_Mac = '" + item.deviceInfo.mac + @"', F_DeviceType = '" + item.deviceInfo.deviceType +
                                                @"', F_ProtocolType = '" + item.deviceInfo.protocolType + @"', F_Status = '" + item.deviceInfo.status +
                                                @"' WHERE F_DeviceId = '" + item.deviceId + @"' AND F_BuildID='" + buildID + @"'
                                        ELSE
                                            INSERT INTO T_DC_DevicesInfo
                                            (F_BuildID, F_DeviceId, F_GatewayId, F_NodeType, F_CreateTime, F_LastModifiedTime, F_NodeId, F_Name, 
                                             F_Description, F_ManufacturerId, F_ManufacturerName, F_Mac, F_DeviceType, F_Model, F_ProtocolType, F_Status  ) VALUES
                                               ( '" + buildID + @"','" + item.deviceId + @"','" + item.gatewayId + @"','" + item.nodeType + @"','" + item.createTime +
                                               @"','" + item.lastModifiedTime + @"','" + item.deviceInfo.nodeId + @"','" + item.deviceInfo.name + @"','" + item.deviceInfo.description +
                                               @"','" + item.deviceInfo.manufacturerId + @"','" + item.deviceInfo.manufacturerName + @"','" + item.deviceInfo.mac + @"','" + item.deviceInfo.deviceType +
                                               @"','" + item.deviceInfo.model + @"','" + item.deviceInfo.protocolType + @"','" + item.deviceInfo.status + 
                                               @"')";

                reslut = reslut +SQLHelper.ExecuteSql(SQLString);
            }
            return reslut;
        }


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
                string totalPower = itemObj["data"]["totalPower"].ToString();
                string batteryVoltage = itemObj["data"]["batteryVoltage"].ToString();
                string color = itemObj["data"]["color"].ToString();
                string switchStatus = itemObj["data"]["switchStatus"].ToString();
                string timestamp = itemObj["timestamp"].ToString();
                //ShowLog("queryDevices Data gatewayId:" + gatewayId);
                //ShowLog("queryDevices Data totalPower:" + totalPower);
                //ShowLog("queryDevices Data batteryVoltage:" + batteryVoltage);
                //ShowLog("queryDevices Data color:" + color);
                //ShowLog("queryDevices Data switchStatus:" + switchStatus);
               
                JObject itemObj2 = JObject.Parse(itemObj["data"].ToString());
                IList<string> datakeys = itemObj2.Properties().Select(p => p.Name).ToList();
                IList<string> dataValues = itemObj2.Properties().Select(p => p.Value.ToString()).ToList();
                for (int j = 0; j < datakeys.Count; j++)
                {
                    Console.WriteLine("queryDevices Data: DataKey->" + datakeys[j] + "  DataValue->" + dataValues[j]);
                    //dataDic.Add(datakeys2[j], dataValues2[j]);
                    //数据插入表：T_OV_MeterOrigValue
                    string SQLString = @"IF EXISTS (SELECT 1 FROM T_OV_MeterOrigValue WHERE F_DeviceId= '" + deviceId +
                                                            @"' AND F_BuildID='" + buildID +
                                                            @"' AND F_TagName='" + datakeys[j] +
                                                            @"' AND F_CalcTime='" + timestamp +
                                                    @"') 
                                            UPDATE T_OV_MeterOrigValue SET F_Value = '" + dataValues[j] + @"', F_UpdataTime = CONVERT(varchar, GETDATE(), 120)" +
                                                    @" WHERE F_DeviceId = '" + deviceId +
                                                    @"' AND F_BuildID='" + buildID +
                                                    @"' AND F_TagName='" + datakeys[j] +
                                                    @"' AND F_CalcTime='" + timestamp +
                                                    @"' 
                                        ELSE
                                            INSERT INTO T_OV_MeterOrigValue
                                            (F_BuildID, F_DeviceId, F_GatewayId, F_TagName, F_Value, F_CalcTime, F_UpdataTime ) VALUES
                                               ( '" + buildID + @"','" + deviceId + @"','" + gatewayId + @"','" + datakeys[j] + @"','" + dataValues[j] + @"','" + timestamp +
                                               @"', CONVERT(varchar, GETDATE(), 120)" +
                                               @")";

                    reslut = reslut + SQLHelper.ExecuteSql(SQLString);
                }
            }
           

               
           
            return reslut;
        }

    }
}
