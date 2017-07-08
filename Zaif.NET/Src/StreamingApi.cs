using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class StreamingApi
    {

        private readonly GlobalSettings settings = GlobalSettings.DefaultSettings;
        private Uri path;

        public ClientWebSocket Client { get; set; }

        public StreamingApi()
        {
            path = new Uri(settings.StreamingApiUrl);
            Client = new ClientWebSocket();
        }

        /// <summary>
        /// Send message buffer size.
        /// </summary>
        const int MessageBufferSize = 256;



        /// <summary>
        /// Zaif Streaming APIを呼び出します。
        /// </summary>
        /// <param name="cp">パラメーター。</param>
        /// <param name="callback">コールバック。</param>
        /// <returns>レスポンスとして返されるJSON形式の文字列。</returns>
        public async Task StartStream(CurrencyPairsEnum cp , Action<StreamingData> callback, CancellationToken token)
        {
            double nonce = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            
            if (Client.State != WebSocketState.Open)
            {
                await Client.ConnectAsync(new Uri(path + cp.ToString()), token);

                var tmpStr = "";

                while (Client.State == WebSocketState.Open)
                {
                    var buff = new ArraySegment<byte>(new byte[MessageBufferSize]);
                    var ret = await Client.ReceiveAsync(buff, token);
                    tmpStr += (new UTF8Encoding()).GetString(buff.Take(ret.Count).ToArray());
                    var index = tmpStr.IndexOf("}{");
                    if (index >= 0)
                    {
                        var json = tmpStr.Substring(0, index + 1);
                        tmpStr = tmpStr.Remove(0, index + 1);
                        var result = JsonConvert.DeserializeObject<StreamingData>(json);
                        callback(result);
                    }
                }
            }
        }

        /// <summary>
        /// Zaif Streaming APIを呼び出します。
        /// </summary>
        /// <param name="param">パラメーター。</param>
        /// <param name="callback">コールバック。</param>
        /// <returns>レスポンスとして返されるJSON形式の文字列。</returns>
        public async Task StartStream(string param, Action<StreamingData> callback, CancellationToken token)
        {
            double nonce = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

            if (Client.State != WebSocketState.Open)
            {
                await Client.ConnectAsync(new Uri(path + param), token);

                var tmpStr = "";

                while (Client.State == WebSocketState.Open)
                {
                    var buff = new ArraySegment<byte>(new byte[MessageBufferSize]);
                    var ret = await Client.ReceiveAsync(buff, token);
                    tmpStr += (new UTF8Encoding()).GetString(buff.Take(ret.Count).ToArray());
                    var index = tmpStr.IndexOf("}{");
                    if (index >= 0)
                    {
                        var json = tmpStr.Substring(0,index + 1);
                        tmpStr = tmpStr.Remove(0,index + 1);
                        var result = JsonConvert.DeserializeObject<StreamingData>(json);
                        callback(result);
                    }
                }
            }
        }
    }
}