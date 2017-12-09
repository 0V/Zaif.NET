using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class PositionHistory : Order
    {
        [JsonProperty("group_id")]
        public int GroupId { get; set; }

        [JsonProperty("your_action")]
        public string YourAction { get; set; }

        [JsonProperty("bid_leverage_id")]
        public int BidLeverageId { get; set; }

        [JsonProperty("ask_leverage_id")]
        public int AskLeverageId { get; set; }


    }
}
