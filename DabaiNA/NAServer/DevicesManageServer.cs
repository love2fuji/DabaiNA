using DabaiNA.HWAuthentication;
using DabaiNA.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabaiNA.NAServer
{
    class DevicesManageServer
    {
        



        /// <summary>
        /// 注册直连设备
        /// </summary>
        /// <param name="nodeId">设备唯一标识码（验证码）</param>
        /// <param name="timeout">设备验证有效期，超时未绑定则设备验证码失效
        ///                       0:永久有效（秒）</param>
        /// <returns></returns>
        public static string RegisterDirectlyConnectedDevice(string nodeId,string devicePSK)
        {
            RegisterDeviceMode registerDevice = new RegisterDeviceMode();
            //设置验证码与设备唯一标识码相同
            registerDevice.verifyCode = nodeId;
            registerDevice.nodeId = nodeId;
            registerDevice.psk = devicePSK;
            registerDevice.timeout = 3600 * 24 * 7;
            //格式化json
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(registerDevice, Newtonsoft.Json.Formatting.Indented);

            string deviceString = AuthenticationServer.GetNorthAPIContent($"reg/v1.2.0/devices?appId={AuthenticationServer.AppID}", "POST", json);
            Console.WriteLine(value: " ----------Device_Register_Response:" + deviceString);
            return deviceString;
        }



        public static string QueryDeviceActivationStatus(string deviceId)
        {
            string result = AuthenticationServer.GetNorthAPIContent($"reg/v1.1.0/devices/{deviceId}?appId={AuthenticationServer.AppID}", "GET");
            return result;
        }

        public static string DeleteDirectlyConnectedDevice(string deviceId)
        {
            string result = AuthenticationServer.GetNorthAPIContent($"dm/v1.1.0/devices/{deviceId}?appId={AuthenticationServer.AppID}&cascade=true", "DELETE");
            return result;
        }

        public static string ModifyDeviceInfo(string deviceId, ModifyDeviceInfoMode modifyDeviceInfoMode)
        {
            //格式化json
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(modifyDeviceInfoMode, Newtonsoft.Json.Formatting.Indented);
            string result = AuthenticationServer.GetNorthAPIContent($"dm/v1.2.0/devices/{deviceId}?appId={AuthenticationServer.AppID}", "PUT", json);
            return result;
        }

    }
}
