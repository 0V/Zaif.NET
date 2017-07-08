using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class LastPrice
    {
        [JsonProperty("last_price")]
        public double Price { get; set; }

    }
}
