using PlugAndTrade.Core.CSVCode;

class Program
{
    static void Main(string[] args)
    {
        var configuration = configurationManager.GetConfiguration();
        
        var DatafilePath = configuration.GetSection("DataPath").Value;
        var CSVFiles = configuration.GetSection("CSVFile").Value;

        while (true)
        {
            
            Console.WriteLine("Välj vad du vill göra med producterna!");
            Console.WriteLine("1: Hämta id \n" +
                              "2: Unika values desc \n" +
                              "3: Groupera på brands \n" +
                              "4: desc brands och desc ids tillhörande brands" +
                              "5: All brand info");
            var input = Console.ReadLine();
            Console.WriteLine("Ge ett namn till din mapp");
            var mapName = Console.ReadLine();
            var productList = ProductFilesRepository.ReadProduct(DatafilePath, input, CSVFiles, mapName);
            //var assortmentList = AssortmentFilesRepository.ReadAssortment(filePath);
            //Console.WriteLine(productList.Length);
            //Console.WriteLine(assortmentList.Length);
        }
    }
}
