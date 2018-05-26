using DabaiNA.Common;
using DabaiNA.DAL;
using DabaiNA.HWAuthentication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabaiNA.NAServer
{
    class DataCollection
    {

        public static void CollectFromAPI()
        {

            System.Threading.Thread.Sleep(30000);
            while (Runtime.m_IsRunning)
            {
                try
                {
                    List<string> devicesList = DataCollectionDAL.GetDevices();

                    foreach (string item in devicesList)
                    {
                        LogHelper.log.Info("查询到 设备ID ：" + item);
                        Runtime.ShowLog("-------- 查询到 设备ID ：" + item);
                        string startTime = DataCollectionDAL.GetDeviceUpdataLastTime(item);
                        LogHelper.log.Info("该设备 最后更新数据的时间为：" + startTime);
                        Runtime.ShowLog("-------- 该设备 最后更新数据的时间为：" + startTime);

                        string queryData = DataCollection.QueryDeviceHistoryData(item, item, startTime);
                        JObject jsonObj = JObject.Parse(queryData);
                        Runtime.ShowLog("queryDevices Data:" + jsonObj.ToString());
                        int totalData = Convert.ToInt32(jsonObj["totalCount"].ToString());
                        //如果查询到设备数据，则存入数据库中
                        if (totalData > 0)
                        {
                            int reslut = DataCollectionDAL.SaveData(jsonObj);
                            LogHelper.log.Info("数据 存入数据库成功，总共：" + +reslut + "条");
                            Runtime.ShowLog("-------- 数据 存入数据库成功，总共：" + reslut + "条");
                        }
                    }

                    System.Threading.Thread.Sleep(20000);
                    continue;
                }
                catch (Exception ex)
                {
                    Runtime.ShowLog("！！！ 采集数据 失败！！！  详细：" + ex.Message);
                    LogHelper.log.Error("！！！ 采集数据 失败！！！  详细：" + ex.Message);
                    System.Threading.Thread.Sleep(20000);
                    continue;
                }
            }

        }

        /// <summary>
        /// 查询平台中的设备
        /// </summary>
        /// <param name="pageNo"> 查询第几页</param>
        /// <param name="pageSize">每页的设备数量</param>
        /// <returns></returns>
        public static string QueryDevice(long pageNo, long pageSize)
        {
            string result = Authentication.GetNorthAPIContent($"dm/v1.3.0/devices?appId={Authentication.AppID}" +
                            $"&pageNo={pageNo}&pageSize={pageSize}", "GET");
            return result;
        }

        /// <summary>
        /// 按条件查询平台中的设备
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <param name="startTime">查询注册设备信息时间在startTime之后的记录，格式：“20151212T121212Z”</param>
        /// <returns>Json数据</returns>
        public static string QueryDevice(long pageNo, long pageSize, string startTime)
        {
            string result = Authentication.GetNorthAPIContent($"dm/v1.3.0/devices?appId={Authentication.AppID}" +
                            $"&pageNo={pageNo}&pageSize={pageSize}&startTime={startTime}", "GET");
            return result;
        }

        /// <summary>
        /// 查询单个设备信息
        /// </summary>
        /// <param name="deviceId">设备ID</param>
        /// <returns>Json数据</returns>
        public static string QueryDeviceInfo(string deviceId)
        {
            string result = Authentication.GetNorthAPIContent($"dm/v1.3.0/devices/{deviceId}?appId={Authentication.AppID}", "GET");
            return result;
        }

        /// <summary>
        /// 查询设备历史数据
        /// </summary>
        /// <param name="deviceId">设备唯一标识</param>
        /// <param name="gatewayId">网关的设备唯一标识</param>
        /// <returns></returns>
        public static string QueryDeviceHistoryData(string deviceId, string gatewayId)
        {
            string result = Authentication.GetNorthAPIContent($"data/v1.1.0/deviceDataHistory?deviceId={deviceId}" +
                $"&gatewayId={gatewayId}", "GET");
            return result;
        }

        /// <summary>
        /// 指定起始时间 查询设备历史数据
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="gatewayId"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public static string QueryDeviceHistoryData(string deviceId, string gatewayId, string startTime)
        {
            string result = Authentication.GetNorthAPIContent($"data/v1.1.0/deviceDataHistory?deviceId={deviceId}" +
                $"&gatewayId={gatewayId}&startTime={startTime}", "GET");
            return result;
        }

        public static string QueryDeviceHistoryData(string deviceId, string gatewayId, string startTime, string endTime)
        {
            string result = Authentication.GetNorthAPIContent($"data/v1.1.0/deviceDataHistory?deviceId={deviceId}" +
                $"&gatewayId={gatewayId}&startTime={startTime}&endTime={endTime}", "GET");
            return result;
        }



    }
}
