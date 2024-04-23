public class Price
{
    public static List<string> readPrice(dynamic filePath)
    {
        IList<string> list = new List<string>();
        DirectoryInfo pricing = new DirectoryInfo(filePath+"Pricings");
        foreach (FileInfo f in pricing.GetFiles())
        {
            string filename = f.FullName;
            string jsonString = File.ReadAllText(filename);
            GetAndSet getAndSet = JsonSerializer.Deserialize<GetAndSet>(jsonString);
            Console.WriteLine(getAndSet);
            // LINQ
        }
        return (List<string>)list;
    }



}
