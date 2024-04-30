using System.Diagnostics;

namespace PlugAndTrade.Core.Switch
{
    public class ProductSwitchProcessor
    {
        public static IEnumerable<string> ProductProcesser(string input, string filePath )
        {
            switch (input)
            {
                case "1":
                    var list = ProductFilesRepository.ReadProduct(filePath);
                    return ProductSwitchMethods.GetProductsIdList(list);
                //case "2":

                //    return ProductSwitchMethods.GetProductsUniqueValueList(list);
                //case "3":
                //    Console.WriteLine("'Alla' eller ett specifikt märke?");
                //    var choose = Console.ReadLine().ToUpper();
                //    return SwitchForSpecificBrand.SelectedBrands(list, choose);
                //case "4":
                //    return ProductSwitchMethods.GetProductInfoOrderByBrandAndIds(list);
                //case "5":
                //    return ProductSwitchMethods.GetProductInfoLines(list);
                //case "6":
                //    return JoinSwitchMethods.getBrandIdsAndStock(product, available);
                //case "7":
                //    return JoinSwitchMethods.CombinEnumerables(product, available, price);
            }
            return null;
        }
    }
}
