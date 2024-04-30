namespace PlugAndTrade.Types;

public class AssortmentFilesRepository
{

    public static AvailabilitiesInfo?[] ReadAssortment(string filePath)
    { 
        var list = GetAssortmentInfo(filePath);
        CsvToFile.WriteToCsv();
       SwitchStateAssortment.switchForAssortment(list);
       
       return list.ToArray();
    }


    private static IEnumerable<AvailabilitiesInfo> GetAssortmentInfo(string filePath)
    {
        var availabilities = new DirectoryInfo(filePath + "Availabilities");
        var count = 0;

        foreach (var f in availabilities.GetFiles())
        {
            if (count >= 99)
            {
                yield break;
            }
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