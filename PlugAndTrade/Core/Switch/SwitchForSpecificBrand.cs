using PlugAndTrade.Core.CSVCode;
namespace PlugAndTrade.Core.Switch
{
    public class SwitchForSpecificBrand
    {
        public static IEnumerable<string> SelectedBrands(IEnumerable<ProductInfo> list, string choose)
        {
            switch (choose)
            {
                case "ALLA":
                    return ProductSwitchMethods.GetAllProductBrands(list);
                case "SPECIFIKT":
                    Console.WriteLine("Vilket märke?");
                    var choosenBrand = Console.ReadLine().ToUpper();
                    return ProductSwitchMethods.GetProductBrand(list, choosenBrand);
            }
            return null;
        }
    }
}
