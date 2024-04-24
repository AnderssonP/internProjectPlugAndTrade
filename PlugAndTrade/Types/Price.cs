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
            ProductInfo productInfo = JsonSerializer.Deserialize<ProductInfo>(jsonString);
            Console.WriteLine(productInfo);
            // LINQ
        }
        return (List<string>)list;
    }



}
