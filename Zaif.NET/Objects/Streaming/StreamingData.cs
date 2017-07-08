using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class StreamingData
    {
        /// <summary>
        /// KeyValuePair の Key が指値 Value が量
        /// </summary>
        [JsonProperty("asks")]
        public IEnumerable<KeyValuePair<double,double>> Asks { get; set; }

        /// <summary>
        /// KeyValuePair の Key が指値 Value が量
        /// </summary>
        [JsonProperty("bids")]
        public IEnumerable<IEnumerable<double>> Bids { get; set; }

        [JsonProperty("trades")]
        public IEnumerable<PublicTrade> Trades { get; set; }

        [JsonProperty("currency_pair")]
        public CurrencyPairsEnum CurrencyPair { get; set; }

        [JsonProperty("last_price")]
        public StreamingLastPrice LastPrice { get; set; }

        [JsonProperty("timestamp")]
        public string TimeStamp { get; set; }
    }
}
