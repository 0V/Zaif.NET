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

        public async Task<TradeBase<Info>> Getinfo()
        {
            var json = await SendPostAsync("get_info").ConfigureAwait(false);
            Console.WriteLine(json);
            var result = JsonConvert.DeserializeObject<TradeBase<Info>>(json);
            return result;
        }

        public async Task<TradeBase<Info>> Getinfo2()
        {
            var json = await SendPostAsync("get_info2").ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<TradeBase<Info>>(json);
            return result;
        }


        public async Task<TradeBase<PersonalInfo>> GetPersonalInfo()
        {
            var json = await SendPostAsync("get_personal_info").ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<TradeBase<PersonalInfo>>(json);
            return result;
        }


        public async Task<TradeBase<IdInfo>> GetIdInfo()
        {
            var json = await SendPostAsync("get_id_info").ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<TradeBase<IdInfo>>(json);
            return result;
        }

        public async Task<TradeBase<Dictionary<string, History>>> TradeHistory(Dictionary<string, string> parameters = null)
        {
            var json = await SendPostAsync("trade_history", parameters).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<TradeBase<Dictionary<string, History>>>(json);
            return result;
        }


        public async Task<TradeBase<ActiveOrder>> ActiveOrders(Dictionary<string, string> parameters = null)
        {
            if (parameters == null) parameters = new Dictionary<string, string>() { { "is_token_both", "true" } };
            else parameters["is_token_both"] = "true";

            var json = await SendPostAsync("active_orders", parameters).ConfigureAwait(false);

            Console.Write(json);

            var result = JsonConvert.DeserializeObject<TradeBase<ActiveOrder>>(json);
            return result;
        }

        public async Task<TradeBase<Trade>> Trades(Dictionary<string, string> parameters = null)
        {
            var json = await SendPostAsync("trades", parameters).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<TradeBase<Trade>>(json);
            return result;
        }

        public async Task<TradeBase<CancelOrder>> CancelOrder(Dictionary<string, string> parameters = null)
        {
            var json = await SendPostAsync("cancel_order", parameters).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<TradeBase<CancelOrder>>(json);
            return result;
        }

        public async Task<TradeBase<Withdraw>> Withdraw(Dictionary<string, string> parameters = null)
        {
            var json = await SendPostAsync("withdraw", parameters).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<TradeBase<Withdraw>>(json);
            return result;
        }

        public async Task<TradeBase<Dictionary<string, DepositHistory>>> DepositHistory(Dictionary<string, string> parameters = null)
        {
            var json = await SendPostAsync("deposit_history", parameters).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<TradeBase<Dictionary<string, DepositHistory>>>(json);
            return result;
        }

        public async Task<TradeBase<Dictionary<string,WithdrawHistory>>> WithdrawHistory(Dictionary<string, string> parameters = null)
        {
            var json = await SendPostAsync("withdraw_history", parameters).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<TradeBase<Dictionary<string, WithdrawHistory>>>(json);
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
