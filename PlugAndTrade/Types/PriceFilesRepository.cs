public class PriceFilesRepository
{
    public static PriceInfo[] ReadPrice(string filePath)
    {
        var list = GetPriceInfo(filePath);

        return list.ToArray();
    }

    private static IEnumerable<PriceInfo> GetPriceInfo(string filePath)
    {
        var prices = new DirectoryInfo(filePath + "Pricings");
        foreach (var price in prices.GetFiles())
        {
            var filename = price.FullName;
            var jsonString = File.ReadAllText(filename);
            var PriceInfo = GetPriceInfoFromJson(jsonString);
            yield return PriceInfo;
        }

    }
    private static PriceInfo GetPriceInfoFromJson(string jsonString)
    {
        return JsonSerializer.Deserialize<PriceInfo>(jsonString)!;
    }
}
