using System.Text.Json.Serialization;

namespace PlugAndTrade.Core.reader
{
    public class ProductInfo
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("sellable")]
        public bool Sellable { get; set; }
        [JsonPropertyName("visible")]

        public bool Visible { get; set; }

        [JsonPropertyName("brand")]

        public string Brand { get; set; }

        [JsonPropertyName("netContent")]

        public NetContent NetContent { get; set; }
    }

    public class NetContent
    {
        [JsonPropertyName("unitOfMeasure")]

        public double UnitOfMeasure { get; set; }
        [JsonPropertyName("value")]

        public double Value { get; set; }
    }

}
