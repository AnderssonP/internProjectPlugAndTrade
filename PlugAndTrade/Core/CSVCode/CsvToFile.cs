namespace PlugAndTrade.Core.CSVCode
{
    public class CsvToFile
    {
        public static void WriteToCsv(IEnumerable<string> stringOfData, string filePlace,string csvFiles)
        {
            var route = $"{csvFiles}{filePlace}.csv";
            using var writer = new StreamWriter(route, true);
            foreach (var line in stringOfData)
            {
                writer.WriteLine(line);
            }
        }
    }
}
