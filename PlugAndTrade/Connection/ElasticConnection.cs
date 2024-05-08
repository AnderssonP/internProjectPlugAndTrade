using Elastic.Clients.Elasticsearch;
using Nest;


namespace PlugAndTrade.Connection
{
    public class ElasticConnection
    {
        public static ElasticClient Connection(string password)
        {
            try
            {
                var settings = new ConnectionSettings(new Uri("https://localhost:9200"))
                    .BasicAuthentication("elastic", password).DefaultIndex("products");

                return new ElasticClient(settings);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }
    }
}
