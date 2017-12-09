using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class CancelPosition
    {
        [JsonProperty("leverage_id")]
        public double LeverageId { get; set; }

        [JsonProperty("timestamp_closed")]
        public string TimeStampClosed { get; set; }

        [JsonProperty("term_end")]
        public string TermEnd { get; set; }

        [JsonProperty("price_avg")]
        public double PriceAvg { get; set; }

        [JsonProperty("amount_done")]
        public double AmountDone { get; set; }

        [JsonProperty("close_avg")]
        public double CloseAvg { get; set; }

        [JsonProperty("close_done")]
        public double CloseDone { get; set; }
        
        [JsonProperty("swap")]
        public double Swap { get; set; }

        [JsonProperty("guard_fee")]
        public double GuardFee { get; set; }

        [JsonProperty("funds")]
        public Dictionary<string, double> Funds { get; set; }
    }
}
