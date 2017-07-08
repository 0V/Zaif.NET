using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZaifNet;


namespace ZaifNET.Tests
{
    # region HttpListener based server
    class Server
    {
        public async void Start(string listenerPrefix)
        {
            // Start up the HttpListener on the passes Uri. 
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(listenerPrefix);
            listener.Start();
            Console.WriteLine("Listening...");

            while (true)
            {
                // Accept the HttpListenerContext
                HttpListenerContext listenerContext = await listener.GetContextAsync();

                // Check if this is for a websocket request
                if (listenerContext.Request.IsWebSocketRequest)
                {
                    ProcessRequest(listenerContext);
                }
                else
                {
                    // Since we are expecting WebSocket requests and this is not - send HTTP 400
                    listenerContext.Response.StatusCode = 400;
                    listenerContext.Response.Close();
                }
            }
        }

        private async void ProcessRequest(HttpListenerContext listenerContext)
        {
            WebSocketContext webSocketContext = null;

            try
            {
                // Accept the WebSocket request
                webSocketContext = await listenerContext.AcceptWebSocketAsync(subProtocol: null);
            }
            catch (Exception ex)
            {
                // If any error occurs then send HTTP Status 500
                listenerContext.Response.StatusCode = 500;
                listenerContext.Response.Close();
                Console.WriteLine("Exception : {0}", ex.Message);
                return;
            }

            // Accept the WebSocket connect. 
            WebSocket webSocket = webSocketContext.WebSocket;

            try
            {
                Random rand = new Random(1);
                while (webSocket.State == WebSocketState.Open)
                {
                    // As long as the WebSocket connection is open - continue sending the random score updates. 
                    string scoreUpdate = "Match A" + ":" + rand.Next(1, 50);
                    Console.WriteLine("Sending Score :" + scoreUpdate);
                    ArraySegment<byte> outputBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(scoreUpdate));
                    await webSocket.SendAsync(outputBuffer, WebSocketMessageType.Text, true, CancellationToken.None);

                    // Wait for some, before sending the next update
                    await Task.Delay(new TimeSpan(0, 0, 3));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : {0}", ex.Message);
            }

            finally
            {
                if (webSocket != null)
                {
                    webSocket.Dispose();
                }
            }
        }
    }
    # endregion 
    class Program
    {
        static string key = "YOUR API KEY";
        static string secret = "YOUR API SECRET";


        static void Main(string[] args)
        {
            // Uri where service will be listening.
            //TestPublicApi();
            //GetPersonalInfo();
            //            TestActiveOrders();
            //TestCurrencyPairs();
            TestStreamApi();
            Console.ReadLine();
            Console.ReadLine();
        }



        static void TestStreamApi()
        {


            var api = new StreamingApi();

            var cs = new CancellationTokenSource();
            using (var stream = File.AppendText("btc_jpy.txt"))
            {
                var res = api.StartStream("btc_jpy", s =>
                {
                    Console.WriteLine(s.LastPrice.Price);
                    stream.WriteLine(s.LastPrice.Price);
                    stream.WriteLine(s.LastPrice.Action);
                    foreach (var item in s.Trades)
                    {
                        stream.WriteLine(item.Date);
                        stream.WriteLine(item.Price);
                        stream.WriteLine(item.Amount);
                    }
                    stream.WriteLine();
                }, cs.Token);

                Console.ReadLine();
            }

            cs.Cancel();
        }

        static void TestCurrencyPairs()
        {
            var api = new PublicApi();
            var res = api.CurrencyPairs("all");
            using (var stream = File.AppendText("cp.txt"))
            {
                foreach (var item in res.Result)
                {
                    stream.WriteLine(item.CurrencyPairValue);
                    Console.WriteLine(item.CurrencyPairValue);
                }
            }
        }

        static void TestPublicApi()
        {
            var api = new PublicApi();
            var res = api.Currencies("all");
            foreach (var item in res.Result)
            {
                Console.WriteLine(item.Name);
            }
        }

        static void TestActiveOrders()
        {
            var api = new TradeApi(key, secret);
            var res = api.ActiveOrders().Result;
            //            Console.WriteLine(res.Return.ActiveOrders["184"].CurrencyPair);
            //            Console.WriteLine(res.Return.TokenActiveOrders["184"].CurrencyPair);
        }


        static void TestTradeApi()
        {
            var api = new TradeApi(key, secret);
            var res = api.Getinfo().Result;
            Console.WriteLine(res.Return.Funds[Currencies.jpy]);
        }

        static void GetPersonalInfo()
        {
            var api = new TradeApi(key, secret);
            var res = api.GetPersonalInfo().Result;
            Console.WriteLine(res.Return.IconPath);
        }


    }

}
