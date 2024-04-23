using Microsoft.Extensions.Configuration;
using PlugAndTrade;

class Program
{
    static void Main(string[] args)
    {
        var configuration = configurationManager.GetConfiguration();
        string filePath = configuration.GetSection("DataPath").Value;

        //List<string> list = Price.readPrice(filePath);
        List<GetAndSet> productList = Product.readProduct(filePath);
        Console.WriteLine(productList.Count);
    }
    
}
