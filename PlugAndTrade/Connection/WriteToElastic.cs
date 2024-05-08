using Elasticsearch.Net;

namespace PlugAndTrade.Connection
{
    public class WriteToElastic
    {
        public static void SendDataToElasticsearch(IEnumerable<ProductInfo> dataStream, string password)
        {
            var client = ElasticConnection.Connection(password);

            var response = client.Bulk(b => b.Index("products").Refresh(Refresh.True).CreateMany(dataStream));

            if (response.IsValid)
            {
                Console.WriteLine("Tillagd");
            }
            else
            {
                Console.WriteLine("Lades inte till");
            }
        }
    }
}
