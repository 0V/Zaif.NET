﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace ZaifNet
{
    public class Info
    {
        [JsonProperty("funds")]
        public Balance Funds { get; set; }

        [JsonProperty("deposit")]
        public Balance Deposit { get; set; }

        [JsonProperty("trade_count")]
        public int TradeCount { get; set; }

        [JsonProperty("open_orders")]
        public int OpenOrders { get; set; }

        [JsonProperty("server_time")]
        public long ServerTime { get; set; }            
    }

    public class Balance
    {
        [JsonProperty("jpy")]
        public string Jpy { get; set; }

        [JsonProperty("mona")]
        public string Mona { get; set; }

        [JsonProperty("btc")]
        public string Btc { get; set; }
    }
    public class Rights
    {
        [JsonProperty("info")]
        public bool Info { get; set; }

        [JsonProperty("trade")]
        public bool Trade { get; set; }

        [JsonProperty("withdraw")]
        public bool Withdraw { get; set; }

        [JsonProperty("personal_info")]
        public bool PersonalInfo { get; set; }

        [JsonProperty("id_info")]
        public bool IdInfo { get; set; }            
    }
}
