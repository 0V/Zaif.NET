using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class ActiveOrder
    {
        [JsonProperty("active_orders")]
        public Dictionary<string, Order> ActiveOrders { get; set; }

        [JsonProperty("token_active_orders")]
        public Dictionary<string, Order> TokenActiveOrders { get; set; }
    }
}
