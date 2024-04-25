public class ProductFilesRepository
{
    public static ProductInfo[] ReadProduct(string filePath,string input)
    {
        var list = GetProductInfo(filePath);
        // LINQ

        switch (input)
        {
            case "1":
                var uniqueValues = list.Select(item => item.NetContent.Value)
                .Distinct().OrderBy(i => i);

                var uniqueList = uniqueValues.ToArray();
                foreach (var value in uniqueList)
                {
                    Console.WriteLine("Unique: " + value);
                    
                }
                Console.WriteLine(uniqueList.Length);
                break;
            case "2":
                var uniqueValuesDec = list.Select(item => item.NetContent.Value)
                    .Distinct().OrderBy(i => -i);
                foreach (var items in uniqueValuesDec)
                {
                    Console.WriteLine(items);
                }
                break;
            case "3":
                Console.WriteLine("'Alla' eller 1 specifikt märke?");
                var choose = Console.ReadLine().ToUpper();
                switch (choose)
                {
                    case "ALLA":
                        var groupQuery = list.GroupBy(p => p.Brand != null ? p.Brand : " null", p => p.Id, (brandName, brandId) => new
                        {
                            Key = brandName,
                            id = string.Join(',', brandId)
                        });

                        foreach (var brand in groupQuery)
                        {
                            Console.WriteLine($"Brand: {brand.Key}");


                        }
                        
                        break;
                    case "1":
                        //var test = groupQuery.ToArray();
                        //Console.WriteLine($"Number of products: {test[1].id}");
                        break;
                }
                break;
            case "4":
                var decAlpaAndIds = list.OrderBy(i => i.Brand).ThenBy(i => i.Id);

                foreach (var brands in decAlpaAndIds)
                {
                    Console.WriteLine(brands.Brand);
                    Console.WriteLine(brands.Id);
                }
                break;
        }

        

        // groupera alla varumärken och skriva ut alla id namn till en sträng.
        

        // sortera på först brand och sen idn.


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
