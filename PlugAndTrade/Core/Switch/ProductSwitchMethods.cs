namespace PlugAndTrade.Core.Switch
{
    public class ProductSwitchMethods
    {
        public static IEnumerable<string> GetProductInfoLines(IEnumerable<ProductInfo> products)
        {
            return products.Select(GetProductInfo);
        }

        public static IEnumerable<string> GetProductInfoOrderByBrandAndIds(IEnumerable<ProductInfo> products)
        {
            return products
                .OrderBy(p => p.Brand)
                .ThenBy(p => p.Id)
                .Select(GetProductInfo);
        }
        private static string GetProductInfo(ProductInfo product)
        {
            return $"Brand: {product.Brand}, ID: {product.Id}, Sellable: {product.Sellable}, " +
                   $"Visible: {product.Visible}, Net Content: {product.NetContent.Value} {product.NetContent.UnitOfMeasure}";
        }

        public static IEnumerable<string> GetProductsUniqueValueList(IEnumerable<ProductInfo> list)
        {
            return list
                .Select(i => i.NetContent.Value)
                .Distinct()
                .OrderBy(i => -i)
                .Select(i => $"Values: {i}");
        }

        public static IEnumerable<string> GetProductsIdList(IEnumerable<ProductInfo> list)
        {
            return list
                .Select(i => i.Id)
                .OrderBy(i => i)
                .Select(i=>$"Id: {i}");
        }

        public static IEnumerable<string> GetAllProductBrands(IEnumerable<ProductInfo> list)
        {
            return GetGroups(list, _=> true);
        }

        public static IEnumerable<string> GetProductBrand(IEnumerable<ProductInfo> list, string chosenBrand)
        {
            return GetGroups(list, p => p.Brand == chosenBrand);
        }
        private static IEnumerable<string> GetGroups(IEnumerable<ProductInfo> list, Func<ProductInfo,bool> filter)
        {
            return list
                .Where(filter)
                .GroupBy(p => p.Brand, p => p.Id)
                .Select(g => $"Brand: {g.Key??"null"}, IDs: {string.Join(", ", g)}");
        }
    }
}
