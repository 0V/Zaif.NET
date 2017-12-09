using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class CommentOrder : Order
    {
        [JsonProperty("comment")]
        public string Comment { get; set; }
    }
}
