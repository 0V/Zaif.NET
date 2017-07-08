using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaifNet
{
    public class PersonalInfo
    {
        [JsonProperty("ranking_nickname")]
        public string RankingNickname { get; set; }

        [JsonProperty("icon_path")]
        public string IconPath { get; set; }
    }
}
