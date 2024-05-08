using System.Diagnostics;
using PlugAndTrade.Connection;
using PlugAndTrade.Types;

namespace PlugAndTrade.Core.Switch
{
    public class ProductSwitchProcessor
    {
        public static IEnumerable<string> ProductProcesser(string input, string filePath )
        {
            var product = ProductFilesRepository.ReadProduct(filePath);
            var available = AssortmentFilesRepository.ReadAssortment(filePath);
            var price = PriceFilesRepository.ReadPrice(filePath);
            switch (input)
            {
                case "1":
                    return ProductSwitchMethods.GetProductsIdList(product);
                case "2":
                    return ProductSwitchMethods.GetProductsUniqueValueList(product);
                case "3":
                    Console.WriteLine("'Alla' eller ett specifikt märke?");
                    var choose = Console.ReadLine().ToUpper();
                    return SwitchForSpecificBrand.SelectedBrands(product, choose);
                case "4":
                    return ProductSwitchMethods.GetProductInfoOrderByBrandAndIds(product);
                case "5":
                    return ProductSwitchMethods.GetProductInfoLines(product);
                case "6":
                    return JoinSwitchMethods.getBrandIdsAndStock(product, available);
                case "7":
                    return JoinSwitchMethods.CombinEnumerables(product, available, price);
                case "8":
                    Console.WriteLine("Vilket varumärke?");
                    var brand = Console.ReadLine().ToUpper();
                    return JoinSwitchMethods.CombinedWithSpecifikBrand(product, available, price, brand);
                case "9":
                    return JoinSwitchMethods.CombinedData(product, available, price);
                    
            }
            return null;
        }
    }
}
