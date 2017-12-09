using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class GetPosition : ActivePosition
    {
        [JsonProperty("timestamp_closed")]
        public string TimeStampClosed { get; set; }
        
        [JsonProperty("guard_fee")]
        public double GuardFee { get; set; }
    }
}

