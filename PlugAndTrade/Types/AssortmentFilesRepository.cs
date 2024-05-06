namespace PlugAndTrade.Types;

public class AssortmentFilesRepository
{

    public static IEnumerable<AvailabilitiesInfo> ReadAssortment(string filePath)
    {
        var list = GetAssortmentInfo(filePath);
        return list;
    }


    private static IEnumerable<AvailabilitiesInfo> GetAssortmentInfo(string filePath)
    {
        var availabilities = new DirectoryInfo(filePath + "Availabilities");
        var count = 0;

        foreach (var f in availabilities.GetFiles())
        {
            //if (count >= 99)
            //{
            //    yield break;
            //}
            var filename = f.FullName;
            var jsonString = File.ReadAllText(filename);
            var availabilitiesInfo = ProductInfo(jsonString);
            count++;
            yield return availabilitiesInfo;
        }
    }

    private static AvailabilitiesInfo ProductInfo(string jsonString)
    {
        return JsonSerializer.Deserialize<AvailabilitiesInfo>(jsonString)!;
    }
}