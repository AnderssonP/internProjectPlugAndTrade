namespace PlugAndTrade.Core.reader
{
    public class AvailabilitiesInfo
    {
        [JsonPropertyName("id")]
        public string id { get; set; }
        [JsonPropertyName("available")]
        public bool Available { get; set; }
        [JsonPropertyName("storeNumber")]
        public string StoreNumber { get; set; }
        [JsonPropertyName("stockStatus")]
        public int StockStatus { get; set; }
    }
}
