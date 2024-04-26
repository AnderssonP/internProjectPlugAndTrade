namespace PlugAndTrade.Core.Switch
{
    internal class SwitchStateAssortment
    {
        public static void switchForAssortment(IEnumerable<AvailabilitiesInfo> list)
        {
            var outOfStock = list.Where(a => a.StockStatus == 0);
            var outOfStockList = outOfStock.ToArray();
            foreach (var o in outOfStock)
            {
                Console.WriteLine(o.StockStatus);
            }
            Console.WriteLine(outOfStockList.Length);
        }
    }
}
