using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZaifNet
{
    public class Currency
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("token")]
        public bool Token { get; set; }

    }
}
