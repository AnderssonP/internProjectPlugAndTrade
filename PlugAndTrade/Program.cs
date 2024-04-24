using Microsoft.Extensions.Configuration;
using PlugAndTrade;
using PlugAndTrade.Types;

class Program
{
    static void Main(string[] args)
    {
        var configuration = configurationManager.GetConfiguration();
        string filePath = configuration.GetSection("DataPath").Value;

        //List<string> list = Price.readPrice(filePath);
        //var productList = ProductFilesRepository.ReadProduct(filePath);
        var assortmentList = AssortmentFilesRepository.ReadAssortment(filePath);
        //Console.WriteLine(productList.Length);
        Console.WriteLine(assortmentList.Length);
    }
    
}
