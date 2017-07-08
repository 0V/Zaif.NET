using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class WithdrawHistory
    {
        [JsonProperty("timestamp")]
        public string TimeStamp { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("txid")]
        public string Txid { get; set; }
    }
}
