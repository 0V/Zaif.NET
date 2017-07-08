using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class IdInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name	")]
        public int Name { get; set; }

        [JsonProperty("kana")]
        public int Kana { get; set; }

        [JsonProperty("certified")]
        public bool Certified { get; set; }
    }
}
