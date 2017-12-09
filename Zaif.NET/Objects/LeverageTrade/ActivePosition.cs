using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class ActivePosition : Order
    {
        [JsonProperty("group_id")]
        public int GroupId { get; set; }

        [JsonProperty("leverage")]
        public double Leverage { get; set; }

        [JsonProperty("limit")]
        public double Limit { get; set; }

        [JsonProperty("stop")]
        public double Stop { get; set; }

        [JsonProperty("fee_spent")]
        public int FeeSpent { get; set; }

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
    }
}
