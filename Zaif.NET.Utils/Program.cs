using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.Generic;

namespace ZaifNET.Utils
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeGenerator.InfoJsonToCode("Code.cs");
        }
    }

    public class Currencies
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("token")]
        public bool Token { get; set; }

    }
}