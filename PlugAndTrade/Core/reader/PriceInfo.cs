namespace PlugAndTrade.Core.reader
{
    public class PriceInfo

    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("hasPrice")]
        public bool HasPrice { get; set; }

        [JsonPropertyName("originalPrice")]
        public double OriginalPrice { get; set; }
        [JsonPropertyName("storeNumber")]
        public string StoreNumber { get; set; }

    }
}
