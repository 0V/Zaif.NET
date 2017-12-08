using System;
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

        public async Task<IEnumerable<Currency>> Currencies(string name = "all")
        {
            var json = await SendGetAsync("/currencies/" + name).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<IEnumerable<Currency>>(json);
            return result;
        }

        public async Task<IEnumerable<CurrencyPair>> CurrencyPairs(string name = "all")
        {
            var json = await SendGetAsync("/currency_pairs/" + name).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<IEnumerable<CurrencyPair>>(json);
            return result;
        }

        public async Task<LastPrice> LastPrice(CurrencyPairsEnum cp)
        {
            var json = await SendGetAsync("/last_price/" + cp.ToString()).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<LastPrice>(json);
            return result;
        }

        public async Task<LastPrice> LastPrice(string name)
        {
            var json = await SendGetAsync("/last_price/" + name).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<LastPrice>(json);
            return result;
        }

        public async Task<Ticker> Ticker(CurrencyPairsEnum cp)
        {
            var json = await SendGetAsync("/ticker/" + cp.ToString()).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<Ticker>(json);
            return result;
        }
       
        public async Task<Ticker> Ticker(string name)
        {
            var json = await SendGetAsync("/ticker/" + name).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<Ticker>(json);
            return result;
        }

        public async Task<IEnumerable<PublicTrade>> Trades(CurrencyPairsEnum cp)
        {
            var json = await SendGetAsync("/trades/" + cp.ToString()).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<IEnumerable<PublicTrade>>(json);
            return result;
        }

        public async Task<IEnumerable<PublicTrade>> Trades(string name)
        {
            var json = await SendGetAsync("/Trade/" + name).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<IEnumerable<PublicTrade>>(json);
            return result;
        }

        public async Task<Depth> Depth(CurrencyPairsEnum cp)
        {
            var json = await SendGetAsync("/depth/" + cp.ToString()).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<Depth>(json);
            return result;
        }

        public async Task<Depth> Depth(string name)
        {
            var json = await SendGetAsync("/depth/" + name).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<Depth>(json);
            return result;
        }

        /// <summary>
        /// Zaif APIを非同期的に呼び出します。
        /// </summary>
        /// <param name="endpoint">エンドポイント。</param>
        /// <returns>レスポンスとして返されるJSON形式の文字列。</returns>
        public async Task<string> SendGetAsync(string endpoint)
        {
            double nonce = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
         
            var res = await Client.GetAsync(path + endpoint).ConfigureAwait(false);

            string text = await res.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!res.IsSuccessStatusCode) return "";

            return text;
        }
    }
}
