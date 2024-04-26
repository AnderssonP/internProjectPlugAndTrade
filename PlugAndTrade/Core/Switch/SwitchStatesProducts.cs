namespace PlugAndTrade.Core.Switch
{
    public class SwitchStatesProducts
    {
        public static void SwitchForProduct(string input, IEnumerable<ProductInfo> list)
        {
            switch (input)
            {
                case "1":
                    var uniqueValues = list.Select(i => i.NetContent.Value)
                        .Distinct().OrderBy(i => i);

                    var uniqueList = uniqueValues.ToArray();
                    foreach (var value in uniqueList)
                    {
                        Console.WriteLine("Unique: " + value);

                    }
                    Console.WriteLine(uniqueList.Length);
                    break;
                case "2":
                    var uniqueValuesDec = list.Select(i => i.NetContent.Value)
                        .Distinct().OrderBy(i => -i);
                    foreach (var items in uniqueValuesDec)
                    {
                        Console.WriteLine(items);
                    }
                    break;
                case "3":
                    Console.WriteLine("'Alla' eller ett specifikt märke?");
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
                        case "SPECIFIKT":
                            //var test = groupQuery.ToArray();
                            //Console.WriteLine($"Number of products: {test[1].id}");
                            Console.WriteLine("Vilket märke?");
                            var choosenBrand = Console.ReadLine().ToUpper();
                            SwitchForSpecifikBrand.SwitchWithDifferentBrands(list,choosenBrand);
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
        }
    }
}
