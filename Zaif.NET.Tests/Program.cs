using System;
using System.Linq;
using ZaifNet;


namespace ZaifNET.Tests
{
    class Program
    {
        static string key = "YOUR API KEY";
        static string secret = "YOUR API SECRET";

        static void Main(string[] args)
        {
            //TestPublicApi();
            //GetPersonalInfo();
            TestActiveOrders();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
        }

        static void TestPublicApi()
        {
            var api = new PublicApi();
            var res = api.Currencies("all");
            Console.WriteLine(res.Result.ToList()[0].Name);
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
