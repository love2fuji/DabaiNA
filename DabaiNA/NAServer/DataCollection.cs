using DabaiNA.HWAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabaiNA.NAServer
{
    class DataCollection
    {
        public static string QueryDevice(long pageNo, long pageSize)
        {
            string result = Authentication.GetNorthAPIContent($"dm/v1.3.0/devices?appId={Authentication.AppID}" +
                            $"&pageNo={pageNo}&pageSize={pageSize}", "GET");
            return result;
        }

        public static string QueryDevice(long pageNo, long pageSize, string startTime)
        {
            string result = Authentication.GetNorthAPIContent($"dm/v1.3.0/devices?appId={Authentication.AppID}" +
                            $"&pageNo={pageNo}&pageSize={pageSize}&startTime={startTime}", "GET");
            return result;
        }

        public static string QueryDeviceData(string deviceId)
        {
            string result = Authentication.GetNorthAPIContent($"dm/v1.3.0/devices/{deviceId}?appId={Authentication.AppID}", "GET");
            return result;
        }


        public static string QueryDeviceHistoryData(string deviceId, string gatewayId)
        {
            string result = Authentication.GetNorthAPIContent($"data/v1.1.0/deviceDataHistory?deviceId={deviceId}" +
                $"&gatewayId={gatewayId}", "GET");
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
