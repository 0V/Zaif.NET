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
    public class LeverageTradeApi
    {
        private readonly GlobalSettings settings = GlobalSettings.DefaultSettings;
        private Uri path;

        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }

        public HttpClient Client { get; set; }

        public LeverageTradeApi()
        {
            path = new Uri(settings.LeverageTradeApiPath, UriKind.Relative);
            Client = new HttpClient();
            Client.BaseAddress = new Uri(settings.BaseApiUrl);
        }

        public LeverageTradeApi(string apiKey, string apiSecret)
        {
            path = new Uri(settings.LeverageTradeApiPath, UriKind.Relative);
            Client = new HttpClient();
            Client.BaseAddress = new Uri(settings.BaseApiUrl);

            ApiKey = apiKey;
            ApiSecret = apiSecret;
        }

        public async Task<TradeBase<Dictionary<string, GetPosition>>> GetPositions(Dictionary<string, string> parameters)
        {
            var json = await SendPostAsync("get_positions").ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<TradeBase<Dictionary<string, GetPosition>>>(json);
            //            var result2 = JsonConvert.DeserializeObject<TradeBase<Dictionary<string,string>>>(json);    
            return result;
        }

        public async Task<TradeBase<Dictionary<string, PositionHistory>>> PositionHistory(Dictionary<string, string> parameters)
        {
            var json = await SendPostAsync("position_history").ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<TradeBase<Dictionary<string, PositionHistory>>>(json);
            return result;
        }


        public async Task<TradeBase<Dictionary<string, ActivePosition>>> ActivePosition(Dictionary<string, string> parameters)
        {
            var json = await SendPostAsync("active_positions").ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<TradeBase<Dictionary<string, ActivePosition>>>(json);
            return result;
        }


        public async Task<TradeBase<CreatePosition>> CreatePosition(Dictionary<string, string> parameters)
        {
            var json = await SendPostAsync("create_position").ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<TradeBase<CreatePosition>>(json);
            return result;
        }

        public async Task<TradeBase<ChangePosition>> ChangePosition(Dictionary<string, string> parameters)
        {
            var json = await SendPostAsync("change_position").ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<TradeBase<ChangePosition>>(json);
            return result;
        }

        public async Task<TradeBase<CancelPosition>> CancelPosition(Dictionary<string, string> parameters)
        {
            var json = await SendPostAsync("cancel_position").ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<TradeBase<CancelPosition>>(json);
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
            string message = await content.ReadAsStringAsync().ConfigureAwait(false);

            var hash = new HMACSHA512(Encoding.UTF8.GetBytes(ApiSecret)).ComputeHash(Encoding.UTF8.GetBytes(message));
            var sign = BitConverter.ToString(hash).ToLower().Replace("-", "");

            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("key", ApiKey);
            Client.DefaultRequestHeaders.Add("sign", sign);

            var res = await Client.PostAsync(path, content).ConfigureAwait(false);

            string text = await res.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!res.IsSuccessStatusCode) return "";

            return text;
        }


    }
}