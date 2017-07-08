using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class StreamingLastPrice
    {
        [JsonProperty("action")]
        public string Action { get; set; }
        
        [JsonProperty("price")]
        public double Price { get; set; }

    }
}
