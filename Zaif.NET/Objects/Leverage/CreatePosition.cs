using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{ 
    public class CreatePosition
    {
        [JsonProperty("leverage_id")]
        public double LeverageId { get; set; }

        [JsonProperty("timestamp")]
        public string TimeStamp { get; set; }

        [JsonProperty("term_end")]
        public string TermEnd { get; set; }

        [JsonProperty("price_avg")]
        public double PriceAvg { get; set; }

        [JsonProperty("amount_done")]
        public double AmountDone { get; set; }

        [JsonProperty("funds")]
        public Dictionary<string,double> Funds { get; set; }
    }
}
