﻿using Newtonsoft.Json;

namespace CexCore.Models.Common
{
    public class Pair
    {
        [JsonProperty("symbol1")]
        public string Symbol1 { get; set; }

        [JsonProperty("symbol2")]
        public string Symbol2 { get; set; }
    }
}
