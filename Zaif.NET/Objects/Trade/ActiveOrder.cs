using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class ActiveOrderChild
    {
        [JsonProperty("token_active_orders")]
        public Dictionary<string, CommentOrder> TokenActiveOrders { get; set; }

        public Dictionary<string, CommentOrder> Orders { get; set; }
    }


    public class ActiveOrder
    {
        [JsonProperty("active_orders")]
        public List<ActiveOrderChild> ActiveOrders { get; set; }
    }
}
