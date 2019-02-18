using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatBotLib.Json
{

    public class FcData
    {
        public bool ready { get; set; }
        public string value { get; set; }
        public int timestamp { get; set; }
        public string message { get; set; }
    }

    public class FcRoot
    {
        public string status { get; set; }
        public FcData data { get; set; }
    }

}
