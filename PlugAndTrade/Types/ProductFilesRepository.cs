public class ProductFilesRepository
{
    public static ProductInfo[] ReadProduct(string filePath)
    {
        var list = GetProductInfo(filePath);
        // LINQ

        //var isNotSellable = list
        //    .Where(p => p.Sellable);

        //var isNotSellableAndHasProductId = isNotSellable
        //    .Where(p => string.IsNullOrEmpty(p.Id))
        //    .ToArray();
        //var isSellable = list.Count(product => product.Sellable);
        //var hasNoId = list.Count(product => product.Id != string.Empty);
        //var ids = list.Select(item => item.Id);
        //int count = 0;
        //foreach (var i in ids )
        //{
        //    count++;
        //}
        //Console.WriteLine();
        var uniqueValues = list.Select(item => item.NetContent.Value)
            .Distinct().OrderBy(i => i);

        var uniqueList = uniqueValues.ToArray();
        foreach (var value in uniqueList)
        {
            Console.WriteLine("Unique: " + value);
            
        }
        Console.WriteLine(uniqueList.Length);
        //Console.WriteLine(isNotSellable);
        //Console.WriteLine(isSellable);
        //Console.WriteLine(hasNoId);

        return list.ToArray();
    }
    private static IEnumerable<ProductInfo> GetProductInfo(string filePath)
    {
        var products = new DirectoryInfo(filePath + "Products");
        foreach (var product in products.GetFiles())
        {
            var filename = product.FullName;
            var jsonString = File.ReadAllText(filename);
            var productInfo = GetProductInfoFromJson(jsonString);
            yield return productInfo;
        }
    }
    private static ProductInfo GetProductInfoFromJson(string jsonString)
    {
        return JsonSerializer.Deserialize<ProductInfo>(jsonString)!;
    }
}
