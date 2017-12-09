using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class History : CommentOrder
    {
        [JsonProperty("fee")]
        public double Fee { get; set; }

        [JsonProperty("your_action")]
        public string YourAction { get; set; }

        [JsonProperty("bonus")]
        public double Bonus { get; set; }

    }
}
