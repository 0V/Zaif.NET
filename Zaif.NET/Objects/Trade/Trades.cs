﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class Trade
    {
        [JsonProperty("received")]
        public int Received { get; set; }

        [JsonProperty("remains")]
        public int Remains { get; set; }

        [JsonProperty("order_id")]
        public int OrderId { get; set; }

        [JsonProperty("funds")]
        public Dictionary<CurrenciesEnum, double> Funds { get; set; }
    }
}
