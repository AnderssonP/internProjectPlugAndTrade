using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugAndTrade.Core.reader
{
    public class PriceInfo


    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("HasPricing")]
        public bool hasPrice { get; set; }

        [JsonPropertyName("OriginalPrice")]
        public double originalPrice { get; set; }
        
    }
}
