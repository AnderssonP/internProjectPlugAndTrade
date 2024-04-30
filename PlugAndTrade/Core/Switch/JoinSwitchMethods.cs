namespace PlugAndTrade.Core.Switch
{
    public class JoinSwitchMethods
    {
        public static IEnumerable<string> getBrandIdsAndStock(IEnumerable<ProductInfo> products, IEnumerable<AvailabilitiesInfo> availabilities)
        {
            var joint = products.Join(availabilities, p => p.Id, a => a.id,(prod,available) => new {brand = prod.Brand, stockstatus = available.StockStatus, id = prod.Id});

            foreach (var item in joint)
            {
                var output = $"Brand: {item.brand} Id: {item.id} StockStatus: {item.stockstatus}";
                yield return output;
            }
        }

        public static IEnumerable<string> CombinEnumerables(IEnumerable<ProductInfo> products,
            IEnumerable<AvailabilitiesInfo> availabilities, IEnumerable<PriceInfo> prices)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return null;
        }
    }
}
