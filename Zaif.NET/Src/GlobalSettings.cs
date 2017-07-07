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
        
    }
}
