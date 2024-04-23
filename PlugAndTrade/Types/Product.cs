using System.Collections;
using System.Timers;

public class Product
{
    public static List<GetAndSet> readProduct(dynamic filePath)
    {
        IList<GetAndSet> list = new List<GetAndSet>();
        DirectoryInfo products = new DirectoryInfo(filePath + "Products");
        foreach (FileInfo product in products.GetFiles())
        {
            string filename = product.FullName;
            string jsonString = File.ReadAllText(filename);
            GetAndSet getAndSet = JsonSerializer.Deserialize<GetAndSet>(jsonString);
            var id = getAndSet.sellable;
            list.Add(getAndSet);
            // lägg till LINQ här för sök i filen.
            Console.WriteLine(list[0]);
        }
        return (List<GetAndSet>)list;
    }

    
}
