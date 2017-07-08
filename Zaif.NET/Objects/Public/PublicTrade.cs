using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class PublicTrade
    {
        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("tid")]
        public long Tid { get; set; }

        [JsonProperty("currency_pair")]
        public CurrencyPairsEnum CurrencyPair { get; set; }

        [JsonProperty("trade_type")]
        public TradeType TradeType { get; set; }        
    }
}
