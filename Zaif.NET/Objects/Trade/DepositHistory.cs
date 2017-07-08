using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class DepositHistory
    {
        [JsonProperty("timestamp")]
        public string TimeStamp { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }
    }
}
