using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabaiNA.Modes
{
    class QueryDevicesMode
    {
        public string totalCount { get; set; }
        public long pageNo { get; set; }
        public long pageSize { get; set; }
        public IList<GetDeviceRspDTO> devices { get; set; }
        
    }
}
