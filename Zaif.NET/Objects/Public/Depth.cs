using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class Depth
    {
        /// <summary>
        /// KeyValuePair の Key が指値 Value が量
        /// </summary>
        [JsonProperty("asks")]
        public IEnumerable<KeyValuePair<double, double>> Asks { get; set; }

        /// <summary>
        /// KeyValuePair の Key が指値 Value が量
        /// </summary>
        [JsonProperty("bids")]
        public IEnumerable<IEnumerable<double>> Bids { get; set; }
    }
}
