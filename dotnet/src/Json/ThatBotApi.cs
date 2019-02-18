using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatBotLib.Json
{
    public class Data
    {
        public int taskId { get; set; }
        public int timestamp { get; set; }
        public string message { get; set; }
    }

    public class ReturnStatus
    {
        public string status { get; set; }
        public Data data { get; set; }
    }
}
