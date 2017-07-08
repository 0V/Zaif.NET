using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class Order
    {
        [JsonProperty("currency_pair")]
        public string CurrencyPair { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("timestamp")]
        public long TimeStamp { get; set; }
    }
}
