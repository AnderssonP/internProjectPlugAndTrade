namespace PlugAndTrade.Types;

public class AssortmentFilesRepository
{

    public static AvailabilitiesInfo?[] ReadAssortment(string filePath)
    {
        var list = GetAssortmentInfo(filePath);

        var outOfStock = list.Where(a => a.StockStatus == 0);
        var outOfStockList = outOfStock.ToArray();
        foreach (var o in outOfStock )
        {
            Console.WriteLine(o.StockStatus);
        }
        Console.WriteLine(outOfStockList.Length);
        return list.ToArray();
    }

    private static IEnumerable<AvailabilitiesInfo> GetAssortmentInfo(string filePath)
    {
        var availabilities = new DirectoryInfo(filePath + "Availabilities");
        foreach (var f in availabilities.GetFiles())
        {
            var filename = f.FullName;
            var jsonString = File.ReadAllText(filename);
            var availabilitiesInfo = ProductInfo(jsonString);
            yield return availabilitiesInfo;
        }
    }

    private static AvailabilitiesInfo ProductInfo(string jsonString)
    {
        return JsonSerializer.Deserialize<AvailabilitiesInfo>(jsonString)!;
    }
}