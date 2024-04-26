using PlugAndTrade;
using PlugAndTrade.Types;

class Program
{
    static void Main(string[] args)
    {
        var configuration = configurationManager.GetConfiguration();
        string filePath = configuration.GetSection("DataPath").Value;
        while (true)
        {
            Console.WriteLine("Välj vad du vill göra med producterna!");
            Console.WriteLine("1: Där values är unika \n" +
                              "2: Unika values desc \n" +
                              "3: Groupera på brands \n" +
                              "4: desc brands och desc ids tillhörande brands");
            string input = Console.ReadLine();

            //List<string> list = Price.readPrice(filePath);
            var productList = ProductFilesRepository.ReadProduct(filePath, input);
            //var assortmentList = AssortmentFilesRepository.ReadAssortment(filePath);
            //Console.WriteLine(productList.Length);
            //Console.WriteLine(assortmentList.Length);
        }

    }
}
