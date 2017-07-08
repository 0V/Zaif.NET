using System;
using System.Collections.Generic;
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
    class Program
    {
        //static string key = "YOUR API KEY";
        //static string secret = "YOUR API SECRET";

        static string key = "f9d8ae77-60a7-48e1-8fee-6782d152c28b";
        static string secret = "34d787a7-4c8e-4c71-8f89-6b96d922471c";

        static void Main(string[] args)
        {
            // Uri where service will be listening.
            //TestPublicApi();
            //GetPersonalInfo();
            //            TestActiveOrders();
            //TestCurrencyPairs();
            //            TestStreamApi();
//            TestDepositHistory();
            TestWithdrawhistrory();
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
                    /*                    foreach (var item in s.Trades)
                                        {
                                            stream.WriteLine(item.Tid);
                                        }*/
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

        static void TestDepositHistory()
        {
            var api = new TradeApi(key, secret);
            var res = api.DepositHistory(new Dictionary<string, string>() { { "currency", "jpy" } }).Result;
            foreach (var item in res.Return)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value.Amount);
            }
        }

        static void TestWithdrawhistrory()
        {
            var api = new TradeApi(key, secret);
            var res = api.WithdrawHistory(new Dictionary<string, string>() { { "currency", "jpy" } }).Result;
            foreach (var item in res.Return)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value.Amount);
            }
        }

        static void TestTradeApi()
        {
            var api = new TradeApi(key, secret);
            var res = api.Getinfo().Result;
            Console.WriteLine(res.Return.Funds[CurrenciesEnum.jpy]);
        }

        static void GetPersonalInfo()
        {
            var api = new TradeApi(key, secret);
            var res = api.GetPersonalInfo().Result;
            Console.WriteLine(res.Return.IconPath);
        }


    }

}
