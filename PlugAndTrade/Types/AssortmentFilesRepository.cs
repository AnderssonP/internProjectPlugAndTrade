namespace PlugAndTrade.Types;

public class AssortmentFilesRepository
{

    public static IEnumerable<AvailabilitiesInfo> ReadAssortment(string filePath)
    {
        var list = GetAssortmentInfo(filePath);
        return list;
    }

    public static IEnumerable<AvailabilitiesInfo> AssortmentProcessor(string filePath, string input, string CSVFiles, string mapName)
    {
        var product = ProductFilesRepository.ReadProduct(filePath);
        var assortment = ReadAssortment(filePath);
        var price = PriceFilesRepository.ReadPrice(filePath);
        CsvToFile.WriteToCsv(JoinSwitchProcessor.JoinProcessor(input, product, assortment, price), mapName, CSVFiles);
        return assortment;
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
            count++;
            yield return availabilitiesInfo;
        }
    }

    private static AvailabilitiesInfo ProductInfo(string jsonString)
    {
        return JsonSerializer.Deserialize<AvailabilitiesInfo>(jsonString)!;
    }
}