﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ZaifNet
{
    public class Group
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("currency_pair")]
        public string CurrencyPair { get; set; }

        [JsonProperty("start_timestamp")]
        public string StartTimeStamp { get; set; }

        [JsonProperty("end_timestamp")]
        public string EndTimeStamp { get; set; }

        [JsonProperty("use_swap")]
        public bool UseSwap { get; set; }

    }
}