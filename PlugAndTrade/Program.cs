using PlugAndTrade.Core.CSVCode;
using PlugAndTrade.Types;

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
                              "4: Desc brands och desc ids tillhörande brands\n" +
                              "5: All brand info\n" +
                              "6: Join med brand,id och stockstatus\n" +
                              "7: Alla kombinerade med brand,id,stockstatus och pris\n" +
                              "8: Kombinerade filer med specifikt brand");
            var input = Console.ReadLine();
            Console.WriteLine("Ge ett namn till din mapp");
            var mapName = Console.ReadLine();
            
             ProductFilesRepository.ProductHandler(DatafilePath, input, CSVFiles, mapName);
            
            //var assortmentList = AssortmentFilesRepository.ReadAssortment(filePath);
            //Console.WriteLine(productList.Length);
            //Console.WriteLine(assortmentList.Length);
        }
    }
}
