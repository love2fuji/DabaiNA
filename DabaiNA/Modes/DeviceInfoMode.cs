using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabaiNA.Modes
{
    class DeviceInfoMode
    {
        public string nodeId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string manufacturerId { get; set; }
        public string manufacturerName { get; set; }
        public string mac { get; set; }
        public string location { get; set; }
        public string deviceType { get; set; }
        public string model { get; set; }
        public string swVersion { get; set; }
        public string fwVersion { get; set; }
        public string hwVersion { get; set; }
        public string protocolType { get; set; }
        public string bridgeId { get; set; }
        public string status { get; set; }
        public string statusDetail { get; set; }
        public string mute { get; set; }
        public string supportedSecurity { get; set; }
        public string isSecurity { get; set; }
        public string signalStrength { get; set; }
        public string sigVersion { get; set; }
        public string serialNumber { get; set; }
        public string batteryLevel { get; set; }

    }
}
