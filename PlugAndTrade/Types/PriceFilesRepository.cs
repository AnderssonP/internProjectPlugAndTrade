public class PriceFilesRepository
{
    public static IEnumerable<PriceInfo> ReadPrice(string filePath)
    {
        var list = GetPriceInfo(filePath);

        return list;
    }

    private static IEnumerable<PriceInfo> GetPriceInfo(string filePath)
    {
        var prices = new DirectoryInfo(filePath + "Pricings");
        var count = 0;
        foreach (var price in prices.GetFiles())
        {
            //if (count >= 99)
            //{
            //    yield break;
            //}
            var filename = price.FullName;
            var jsonString = File.ReadAllText(filename);
            var PriceInfo = GetPriceInfoFromJson(jsonString);
            count++;
            yield return PriceInfo;
        }

    }
    private static PriceInfo GetPriceInfoFromJson(string jsonString)
    {
        return JsonSerializer.Deserialize<PriceInfo>(jsonString)!;
    }
}
