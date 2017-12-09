using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet.Utils
{
    public class UtilsCurrencies
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("token")]
        public bool Token { get; set; }

    }

    public class CodeGenerator
    {
        public static void InfoJsonToCode(string fileName)
        {
            string json = @"[{'id': 92, 'name': 'PEPECASH', 'is_token': true}, {'id': 123, 'name': 'SHIMARENABG', 'is_token': true}, {'id': 120, 'name': 'RURUBG', 'is_token': true}, {'id': 134, 'name': 'YOGIBOGOCPFV', 'is_token': true}, {'id': 22, 'name': 'MAGATAMARDSX', 'is_token': true}, {'id': 52, 'name': 'MAGATAMABLON', 'is_token': true}, {'id': 38, 'name': 'MAGATAMAGNON', 'is_token': true}, {'id': 41, 'name': 'MAGATAMAGNFR', 'is_token': true}, {'id': 79, 'name': 'MAMICHANNEL', 'is_token': true}, {'id': 37, 'name': 'MAGATAMAVTSV', 'is_token': true}, {'id': 105, 'name': 'XACSIX', 'is_token': true}, {'id': 53, 'name': 'MAGATAMABLTW', 'is_token': true}, {'id': 124, 'name': 'RUMIRUMIBG', 'is_token': true}, {'id': 13, 'name': 'MAGATAMAGN', 'is_token': true}, {'id': 42, 'name': 'MAGATAMAGNFV', 'is_token': true}, {'id': 135, 'name': 'YOGIBOGOCPSX', 'is_token': true}, {'id': 75, 'name': 'TSUKASA', 'is_token': true}, {'id': 107, 'name': 'XACEIGHT', 'is_token': true}, {'id': 65, 'name': 'MAGATAMAWTSV', 'is_token': true}, {'id': 44, 'name': 'MAGATAMAGNSV', 'is_token': true}, {'id': 133, 'name': 'YOGIBOGOCPFR', 'is_token': true}, {'id': 137, 'name': 'JPYZ', 'is_token': true}, {'id': 114, 'name': 'TSUKASABG', 'is_token': true}, {'id': 24, 'name': 'MAGATAMAYLON', 'is_token': true}, {'id': 100, 'name': 'XACONE', 'is_token': true}, {'id': 40, 'name': 'MAGATAMAGNTH', 'is_token': true}, {'id': 29, 'name': 'MAGATAMAYLSX', 'is_token': true}, {'id': 76, 'name': 'KAORI', 'is_token': true}, {'id': 130, 'name': 'YOGIBOGOCPON', 'is_token': true}, {'id': 43, 'name': 'MAGATAMAGNSX', 'is_token': true}, {'id': 61, 'name': 'MAGATAMAWTTH', 'is_token': true}, {'id': 84, 'name': 'DJASANYANVIX', 'is_token': true}, {'id': 26, 'name': 'MAGATAMAYLTH', 'is_token': true}, {'id': 54, 'name': 'MAGATAMABLTH', 'is_token': true}, {'id': 62, 'name': 'MAGATAMAWTFR', 'is_token': true}, {'id': 11, 'name': 'MAGATAMAYL', 'is_token': true}, {'id': 99, 'name': 'CICC', 'is_token': true}, {'id': 67, 'name': 'FSCC', 'is_token': true}, {'id': 87, 'name': 'MIZUKIVIX', 'is_token': true}, {'id': 104, 'name': 'XACFIVE', 'is_token': true}, {'id': 90, 'name': 'BITGIRLSI', 'is_token': true}, {'id': 14, 'name': 'MAGATAMATQ', 'is_token': true}, {'id': 49, 'name': 'MAGATAMATQFV', 'is_token': true}, {'id': 132, 'name': 'YOGIBOGOCPTH', 'is_token': true}, {'id': 39, 'name': 'MAGATAMAGNTW', 'is_token': true}, {'id': 121, 'name': 'KINOBG', 'is_token': true}, {'id': 80, 'name': 'HINANOMAI', 'is_token': true}, {'id': 57, 'name': 'MAGATAMABLSX', 'is_token': true}, {'id': 82, 'name': 'ICHARLOTTE', 'is_token': true}, {'id': 35, 'name': 'MAGATAMAVTFV', 'is_token': true}, {'id': 118, 'name': 'MAMICHANBG', 'is_token': true}, {'id': 31, 'name': 'MAGATAMAVTON', 'is_token': true}, {'id': 112, 'name': 'SATOAYAKABG', 'is_token': true}, {'id': 96, 'name': 'SHIMARENA', 'is_token': true}, {'id': 126, 'name': 'LEENABG', 'is_token': true}, {'id': 91, 'name': 'BITGIRLSII', 'is_token': true}, {'id': 72, 'name': 'CHIKARIN', 'is_token': true}, {'id': 15, 'name': 'MAGATAMABL', 'is_token': true}, {'id': 28, 'name': 'MAGATAMAYLFV', 'is_token': true}, {'id': 85, 'name': 'CHIKARINVIX', 'is_token': true}, {'id': 34, 'name': 'MAGATAMAVTFR', 'is_token': true}, {'id': 115, 'name': 'MIZUKIBG', 'is_token': true}, {'id': 55, 'name': 'MAGATAMABLFR', 'is_token': true}, {'id': 17, 'name': 'MAGATAMARDON', 'is_token': true}, {'id': 119, 'name': 'HINANOMAIBG', 'is_token': true}, {'id': 5, 'name': 'ZAIF', 'is_token': true}, {'id': 71, 'name': 'DJASANYAN', 'is_token': true}, {'id': 136, 'name': 'MAGATAMABZ', 'is_token': true}, {'id': 77, 'name': 'MIZUKI', 'is_token': true}, {'id': 51, 'name': 'MAGATAMATQSV', 'is_token': true}, {'id': 30, 'name': 'MAGATAMAYLSV', 'is_token': true}, {'id': 89, 'name': 'RISAVIX', 'is_token': true}, {'id': 94, 'name': 'YAMAGUCHIA', 'is_token': true}, {'id': 2, 'name': 'xem', 'is_token': false}, {'id': 8, 'name': 'SJCX', 'is_token': true}, {'id': 109, 'name': 'KAORIBG', 'is_token': true}, {'id': 21, 'name': 'MAGATAMARDFV', 'is_token': true}, {'id': 102, 'name': 'XACTHREE', 'is_token': true}, {'id': 20, 'name': 'MAGATAMARDFR', 'is_token': true}, {'id': 68, 'name': 'TOREKABUOPT', 'is_token': true}, {'id': 36, 'name': 'MAGATAMAVTSX', 'is_token': true}, {'id': 4, 'name': 'mona', 'is_token': false}, {'id': 60, 'name': 'MAGATAMAWTTW', 'is_token': true}, {'id': 98, 'name': 'ITSUKI', 'is_token': true}, {'id': 9, 'name': 'MAGATAMAMIJN', 'is_token': true}, {'id': 45, 'name': 'MAGATAMATQON', 'is_token': true}, {'id': 59, 'name': 'MAGATAMAWTON', 'is_token': true}, {'id': 66, 'name': 'HYOU', 'is_token': true}, {'id': 117, 'name': 'ICHARLOTTEBG', 'is_token': true}, {'id': 50, 'name': 'MAGATAMATQSX', 'is_token': true}, {'id': 78, 'name': 'SHIRAHOSHI', 'is_token': true}, {'id': 6, 'name': 'XCP', 'is_token': true}, {'id': 63, 'name': 'MAGATAMAWTFV', 'is_token': true}, {'id': 58, 'name': 'MAGATAMABLSV', 'is_token': true}, {'id': 93, 'name': 'KINOKOUSAKA', 'is_token': true}, {'id': 97, 'name': 'LEENA', 'is_token': true}, {'id': 33, 'name': 'MAGATAMAVTTH', 'is_token': true}, {'id': 64, 'name': 'MAGATAMAWTSX', 'is_token': true}, {'id': 69, 'name': 'NEMCARD', 'is_token': true}, {'id': 12, 'name': 'MAGATAMAVT', 'is_token': true}, {'id': 16, 'name': 'MAGATAMAWT', 'is_token': true}, {'id': 131, 'name': 'YOGIBOGOCPTW', 'is_token': true}, {'id': 47, 'name': 'MAGATAMATQTH', 'is_token': true}, {'id': 125, 'name': 'ITSUKIBG', 'is_token': true}, {'id': 110, 'name': 'CHIKARINBG', 'is_token': true}, {'id': 101, 'name': 'XACTWO', 'is_token': true}, {'id': 19, 'name': 'MAGATAMARDTH', 'is_token': true}, {'id': 95, 'name': 'RUMIRUMI', 'is_token': true}, {'id': 3, 'name': 'jpy', 'is_token': false}, {'id': 88, 'name': 'SIRAHOSIVIX', 'is_token': true}, {'id': 23, 'name': 'MAGATAMARDSV', 'is_token': true}, {'id': 1, 'name': 'btc', 'is_token': false}, {'id': 122, 'name': 'YAMAGUCHIABG', 'is_token': true}, {'id': 32, 'name': 'MAGATAMAVTTW', 'is_token': true}, {'id': 18, 'name': 'MAGATAMARDTW', 'is_token': true}, {'id': 70, 'name': 'PACHI', 'is_token': true}, {'id': 86, 'name': 'TSUKASAVIX', 'is_token': true}, {'id': 108, 'name': 'XACNINE', 'is_token': true}, {'id': 74, 'name': 'SATOAYAKA', 'is_token': true}, {'id': 106, 'name': 'XACSEVEN', 'is_token': true}, {'id': 116, 'name': 'SHIRAHOSHIBG', 'is_token': true}, {'id': 113, 'name': 'DJASANYANBG', 'is_token': true}, {'id': 56, 'name': 'MAGATAMABLFV', 'is_token': true}, {'id': 81, 'name': 'RURU', 'is_token': true}, {'id': 7, 'name': 'BITCRYSTALS', 'is_token': true}, {'id': 129, 'name': 'NCXC', 'is_token': true}, {'id': 10, 'name': 'MAGATAMARD', 'is_token': true}, {'id': 25, 'name': 'MAGATAMAYLTW', 'is_token': true}, {'id': 103, 'name': 'XACFOUR', 'is_token': true}, {'id': 27, 'name': 'MAGATAMAYLFR', 'is_token': true}, {'id': 46, 'name': 'MAGATAMATQTW', 'is_token': true}, {'id': 48, 'name': 'MAGATAMATQFR', 'is_token': true}, {'id': 73, 'name': 'SANOMAYA', 'is_token': true}, {'id': 83, 'name': 'SANOMAYAVIX', 'is_token': true}, {'id': 111, 'name': 'SANOMAYABG', 'is_token': true}]";

            var j = JsonConvert.DeserializeObject<List<UtilsCurrencies>>(json);

            var sb = new StringBuilder();

            var ordered = j.OrderBy(c => c.Id);
           

            Console.WriteLine( );

            foreach (var item in ordered)
            {
                //                sb.AppendFormat("        [JsonProperty(\"{0}\")]\n", item.Name);
                //               sb.AppendFormat("        public string {0} { get; set; }\n\n", item.Name);
                sb.AppendLine("        " + item.Name + ",");
            }

            System.IO.File.WriteAllText(fileName, sb.ToString());
        }


        public static void CurrencyPairsJsonToCode(string fileName)
        {
            var api = new PublicApi();
            var res = api.CurrencyPairs("all").Result;
            //            var ordered = res.Result.OrderBy(c => c.CurrencyPairValue);
            using (var stream = File.AppendText(fileName))
            {
                foreach (var item in res)
                {
                    stream.WriteLine("        " + item.CurrencyPairValue + ",");
                }
            }
        }

        public static void CurrenciesJsonToCode(string fileName)
        {
            var api = new PublicApi();
            var res = api.Currencies("all").Result;
            //            var ordered = res.Result.OrderBy(c => c.CurrencyPairValue);
            using (var stream = File.AppendText(fileName))
            {
                foreach (var item in res)
                {
                    stream.WriteLine("        " + item.Name + ",");
                }
            }
        }
    }
}
