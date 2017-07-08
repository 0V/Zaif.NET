using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.Generic;

namespace ZaifNet.Utils
{
    class Program
    {
        static void Main(string[] args)
        {
            //            CodeGenerator.InfoJsonToCode("Code.txt");
            CodeGenerator.CurrencyPairsJsonToCode("currency_paies.txt");
        }
    }

}