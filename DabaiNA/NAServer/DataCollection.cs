using DabaiNA.HWAuthentication;
using Newtonsoft.Json;
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
        public static T DeserializeJsonToObject<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
            T t = o as T;
            return t;
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
        public static string QueryDeviceData(string deviceId)
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
