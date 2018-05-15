using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabaiNA.Modes
{
    class GetDeviceRspDTO
    {
        public string deviceId { get; set; }
        public string gatewayId { get; set; }
        public string nodeType { get; set; }
        public string createTime { get; set; }
        public string lastModifiedTime { get; set; }
        public DeviceInfoMode deviceInfo { get; set; }
        public IList<DeviceServiceMode> services { get; set; }

        //public string connectionInfo { get; set; }
        //public string location { get; set; }
        //public string devGroupIds { get; set; }

    }
}
