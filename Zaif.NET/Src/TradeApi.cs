using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace ZaifNet
{
    public class TradeApi
    {
        private readonly GlobalSettings settings = GlobalSettings.DefaultSettings;
        private Uri path;

        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }

        public HttpClient Client { get; set; } 

        public TradeApi() {
            path = new Uri(settings.TradeApiPath, UriKind.Relative);
            Client = new HttpClient();
            Client.BaseAddress = new Uri(settings.BaseApiUrl);
        }

        public TradeApi(string apiKey, string apiSecret)
        {
            path = new Uri(settings.TradeApiPath, UriKind.Relative);
            Client = new HttpClient();
            Client.BaseAddress = new Uri(settings.BaseApiUrl);

            ApiKey = apiKey;
            ApiSecret = apiSecret;
        }

        public async Task<Trade<Info>> Getinfo()
        {
            var json = await SendPostAsync("get_info");
            Console.WriteLine(json);
            var result = JsonConvert.DeserializeObject<Trade<Info>>(json);
            return result;
        }

        public async Task<Trade<Info>> Getinfo2()
        {
            var json = await SendPostAsync("get_info2");
            var result = JsonConvert.DeserializeObject<Trade<Info>>(json);
            return result;
        }

        public async Task<Trade<Info>> TradeHistory(Dictionary<string,string> parameters)
        {
            var json = await SendPostAsync("trade_history", parameters);
            var result = JsonConvert.DeserializeObject<Trade<Info>>(json);
            return result;
        }
        
        /// <summary>
        /// Zaif APIを非同期的に呼び出します。
        /// </summary>
        /// <param name="endpoint">APIのメソッド名。</param>
        /// <param name="parameters">APIのパラメータのリスト。</param>
        /// <returns>レスポンスとして返されるJSON形式の文字列。</returns>
        public async Task<string> SendPostAsync(string method, Dictionary<string, string> parameters = null)
        {
            double nonce = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

            if (parameters == null) parameters = new Dictionary<string, string>();
            parameters.Add("nonce", nonce.ToString());
            parameters.Add("method", method);

            var content = new FormUrlEncodedContent(parameters);
            string message = await content.ReadAsStringAsync();

            var hash = new HMACSHA512(Encoding.UTF8.GetBytes(ApiSecret)).ComputeHash(Encoding.UTF8.GetBytes(message));
            var sign = BitConverter.ToString(hash).ToLower().Replace("-", "");

            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("key", ApiKey);
            Client.DefaultRequestHeaders.Add("Sign", sign);

            var res = await Client.PostAsync(path, content);

            string text = await res.Content.ReadAsStringAsync();

            if (!res.IsSuccessStatusCode) return "";

            return text;
        }


    }
}
