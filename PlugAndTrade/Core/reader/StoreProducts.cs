using System.Collections;

namespace PlugAndTrade.Core.reader
{
    internal class StoreProduct
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("Brand")]
        public string Brand { get; set; }

        public CombinedProduct CombinedProducts { get; set; }
    }

    public class CombinedProduct
    {

        [JsonPropertyName("storeNumber")]
        public string StoreNumber { get; set; }

        [JsonPropertyName("available")]
        public bool Available { get; set; }

        [JsonPropertyName("stockStatus")]
        public int StockStatus { get; set; }

        [JsonPropertyName("originalPrice")]
        public double OriginalPrice { get; set; }

        [JsonPropertyName("hasPrice")]
        public bool HasPrice { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
