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
    public class FuturePublicApi
    {

        private readonly GlobalSettings settings = GlobalSettings.DefaultSettings;
        private Uri path;

        public HttpClient Client { get; set; }

        public FuturePublicApi()
        {
            path = new Uri(settings.BaseApiUrl + settings.PublicApiPath);
            Client = new HttpClient();
        }

        public async Task<IEnumerable<Group>> Groups(string groupId = "all")
        {
            string endpoint = "/groups/" + groupId;

            var json = await SendGetAsync(endpoint).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<IEnumerable<Group>>(json);
            return result;
        }

        public async Task<IEnumerable<FutureLastPrice>> LastPrice(string groupId = "all", string currencyPair = "")
        {
            string endpoint;
            if (string.IsNullOrWhiteSpace(currencyPair)) endpoint = "/last_price/" + groupId;
            else endpoint = "/last_price/" + groupId + "/" + currencyPair;

            var json = await SendGetAsync(endpoint).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<IEnumerable<FutureLastPrice>>(json);
            return result;
        }

        public async Task<LastPrice> LastPrice(string groupId = "all", CurrencyPairsEnum cp = CurrencyPairsEnum.None)
        {
            string endpoint;
            if (cp == CurrencyPairsEnum.None) endpoint = "/last_price/" + groupId;
            else endpoint = "/last_price/" + groupId + "/" + cp.ToString();

            var json = await SendGetAsync(endpoint).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<LastPrice>(json);
            return result;
        }

        public async Task<Ticker> Ticker(string groupId, string currencyPair)
        {
            string endpoint = "/ticker/" + groupId + "/" + currencyPair;

            var json = await SendGetAsync(endpoint).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<Ticker>(json);
            return result;
        }

        public async Task<Ticker> Ticker(string groupId, CurrencyPairsEnum cp)
        {
            string endpoint = "/ticker/" + groupId + "/" + cp.ToString();

            var json = await SendGetAsync(endpoint).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<Ticker>(json);
            return result;
        }

        public async Task<IEnumerable<PublicTrade>> Trades(string groupId, string currencyPair)
        {
            string endpoint = "/trades/" + groupId + "/" + currencyPair;

            var json = await SendGetAsync(endpoint).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<IEnumerable<PublicTrade>>(json);
            return result;
        }

        public async Task<IEnumerable<PublicTrade>> Trades(string groupId, CurrencyPairsEnum cp)
        {
            string endpoint = "/trades/" + groupId + "/" + cp.ToString();

            var json = await SendGetAsync(endpoint).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<IEnumerable<PublicTrade>>(json);
            return result;
        }

        public async Task<Depth> Depth(string groupId, string currencyPair)
        {
            string endpoint = "/depth/" + groupId + "/" + currencyPair;

            var json = await SendGetAsync(endpoint).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<Depth>(json);
            return result;
        }

        public async Task<Depth> Depth(string groupId, CurrencyPairsEnum cp)
        {
            string endpoint = "/depth/" + groupId + "/" + cp.ToString();

            var json = await SendGetAsync(endpoint).ConfigureAwait(false);
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
