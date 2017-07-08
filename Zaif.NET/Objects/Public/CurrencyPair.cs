using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZaifNet
{
    public class CurrencyPair
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("currency_pair")]
        public CurrencyPairsEnum CurrencyPairValue { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("is_token")]
        public bool IsToken{ get; set; }

        [JsonProperty("event_number")]
        public int EventNumber { get; set; }

        [JsonProperty("item_unit_min")]
        public double ItemUnitMin { get; set; }

        [JsonProperty("item_unit_step")]
        public double ItemUnitStep { get; set; }

        [JsonProperty("aux_unit_min")]
        public double AuxUnitMin { get; set; }

        [JsonProperty("aux_unit_step")]
        public double AuxUnitSteo { get; set; }

    }
}