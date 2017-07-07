using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZaifNet
{
    public class Trade<T>
    {
        [JsonProperty("success")]
        public int Success { get; set; }

        [JsonProperty("return")]
        public T Return { get; set; }
    }
}
