using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{ 
    public class Withdraw
    {
        // Always Empty
        //        [JsonProperty("txid")]
        //        public string Txid { get; set; }

        [JsonProperty("fee")]
        public double Fee { get; set; }

        [JsonProperty("funds")]
        public Dictionary<CurrenciesEnum, double> Funds { get; set; }
    }
}
