﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;

namespace ZaifNet
{
    public class PublicApi
    {

        private readonly GlobalSettings settings = GlobalSettings.DefaultSettings;
        private Uri path;

        public HttpClient Client { get; set; }

        public PublicApi()
        {
            path = new Uri(settings.BaseApiUrl + settings.PublicApiPath);
            Client = new HttpClient();
        }

        public async Task<IEnumerable<Currency>> Currencies(string name)
        {
            var json = await SendGetAsync("/currencies/" + name);
            Console.WriteLine(json);
            var result = JsonConvert.DeserializeObject<IEnumerable<Currency>>(json);
            return result;
        }
        
        /// <summary>
        /// Zaif APIを非同期的に呼び出します。
        /// </summary>
        /// <param name="endpoint">APIのメソッド名。</param>
        /// <param name="parameters">APIのパラメータのリスト。</param>
        /// <returns>レスポンスとして返されるJSON形式の文字列。</returns>
        public async Task<string> SendGetAsync(string endpoint)
        {
            double nonce = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
         
            var res = await Client.GetAsync(path + endpoint);

            string text = await res.Content.ReadAsStringAsync();

            Console.WriteLine(path + endpoint);

            if (!res.IsSuccessStatusCode) return "";

            return text;
        }
    }
}
