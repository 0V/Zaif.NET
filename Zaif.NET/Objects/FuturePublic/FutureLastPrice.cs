using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class FutureLastPrice
    {
        [JsonProperty("last_price")]
        public double LastPrice { get; set; }

        [JsonProperty("group_id")]
        public int GroupId { get; set; }
    }
}
