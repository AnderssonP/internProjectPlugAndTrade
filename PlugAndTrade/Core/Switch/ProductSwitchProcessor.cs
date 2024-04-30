namespace PlugAndTrade.Core.Switch
{
    public class ProductSwitchProcessor
    {
        public static IEnumerable<string> ProductProcesser(string input, IEnumerable<ProductInfo> list)
        {
            switch (input)
            {
                case "1":
                    return ProductSwitchMethods.GetProductsIdList(list);
                case "2":
                    return ProductSwitchMethods.GetProductsUniqueValueList(list);
                case "3":
                    Console.WriteLine("'Alla' eller ett specifikt märke?");
                    var choose = Console.ReadLine().ToUpper();
                    return SwitchForSpecificBrand.SelectedBrands(list, choose);
                case "4":
                    return ProductSwitchMethods.GetProductInfoOrderByBrandAndIds(list);
                case "5":
                    return ProductSwitchMethods.GetProductInfoLines(list);
            }
            return null;
        }
    }
}
