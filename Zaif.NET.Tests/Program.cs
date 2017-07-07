using System;
using System.Linq;
using ZaifNet;


namespace ZaifNET.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            TestPublicApi();
            TestTradeApi();
            Console.ReadLine();
        }

        static void TestPublicApi()
        {

            var api = new PublicApi();
            var res = api.Currencies("all");
            Console.WriteLine(res.Result.ToList()[0].Name);
        }

        static void TestTradeApi()
        {
            string key = "YOUR API KEY";
            string secret = "YOUR API SECRET";
            var api = new TradeApi(key, secret);
            var res = api.Getinfo().Result;
            Console.WriteLine(res.Return.Funds.Jpy);
        }

    }

}
