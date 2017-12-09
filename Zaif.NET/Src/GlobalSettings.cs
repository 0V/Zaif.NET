using System;
using System.Collections.Generic;
using System.Text;

namespace ZaifNet
{
    public class GlobalSettings
    {
        internal static readonly GlobalSettings DefaultSettings = new GlobalSettings();
        public string BaseApiUrl { get; set; } = "https://api.zaif.jp";
        public string PublicApiPath { get; set; } = "/api/1";
        public string TradeApiPath { get; set; } = "/tapi";
        public string FuturePublicApiPath { get; set; } = "/fapi/1";
        public string LeverageTradeApiPath { get; set; } = "/tlapi";
        public string StreamingApiUrl { get; set; } = "wss://ws.zaif.jp:8888/stream?currency_pair=";

    }
}
