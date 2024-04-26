public class ProductFilesRepository
{
    public static ProductInfo[] ReadProduct(string filePath,string input)
    {
        var list = GetProductInfo(filePath);

        SwitchStatesProducts.SwitchForProduct(input, list);

        return list.ToArray();
    }

    private static IEnumerable<ProductInfo> GetProductInfo(string filePath)
    {
        var products = new DirectoryInfo(filePath + "Products");
        var count = 0;
        
        foreach (var product in products.GetFiles())
        {
            if (count >= 99)
            {
                yield break;
            }
            var filename = product.FullName;
            var jsonString = File.ReadAllText(filename);
            var productInfo = GetProductInfoFromJson(jsonString);
            count++;
            yield return productInfo;
        }
    }
    private static ProductInfo GetProductInfoFromJson(string jsonString)
    {
        return JsonSerializer.Deserialize<ProductInfo>(jsonString)!;
    }
}
