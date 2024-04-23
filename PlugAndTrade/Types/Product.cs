using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Timers;

public class Product
{
    public static List<GetAndSet> readProduct(dynamic filePath)
    {
        int i = 0;
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
            //Console.WriteLine(list[i].visible);
            i++;
        }
        var isNotSellable = list.Count(product =>  product.sellable != true);
        var isSellable = list.Count(product => product.sellable == true);
        var hasNoId = list.Count(product => product.id != string.Empty);
        IList<double> values = new List<double>();
        foreach(var item in list)
        {
            values.Add(item.netContent.value);
        }
        double[] uniqueValues = values.Distinct().ToArray();
        foreach (var item in uniqueValues)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine(isNotSellable);
        Console.WriteLine(isSellable);
        Console.WriteLine(hasNoId);
        //foreach(var item in isVisible)
        //{
        //    Console.WriteLine(item.id);
        //}

        return (List<GetAndSet>)list;
    }

    
}
