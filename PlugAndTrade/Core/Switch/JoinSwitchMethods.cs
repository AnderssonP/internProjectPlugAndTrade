using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using PlugAndTrade.Types;

namespace PlugAndTrade.Core.Switch
{
    public class JoinSwitchMethods
    {
        public static IEnumerable<string> getBrandIdsAndStock(IEnumerable<ProductInfo> products, IEnumerable<AvailabilitiesInfo> availabilities)
        {
            try
            {
            return products.Join(availabilities, p => p.Id, a => a.id, (prod, available) => new { prod.Brand, available.StockStatus, prod.Id }
                )
                .Select(item => $"Brand: {item.Brand} Id: {item.Id} StockStatus: {item.StockStatus}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static IEnumerable<string> CombinEnumerables(IEnumerable<ProductInfo> products,
            IEnumerable<AvailabilitiesInfo> availabilities, IEnumerable<PriceInfo> prices)
        {
            return JoinAllData(products, availabilities, prices,_=> true);
        }
        public static IEnumerable<string> CombinedWithSpecifikBrand(IEnumerable<ProductInfo> products,
            IEnumerable<AvailabilitiesInfo> availabilities, IEnumerable<PriceInfo> prices, string specifikBrand)
        {
            return JoinAllData(products, availabilities, prices,p => p.Brand == specifikBrand);
        }

        private static IEnumerable<string> JoinAllData(IEnumerable<ProductInfo> products, IEnumerable<AvailabilitiesInfo> availabilities, IEnumerable<PriceInfo> prices, Func<ProductInfo, bool> filter)
        {
            return products
                    .Where(filter)
                    .Join(availabilities, p => p.Id, a => a.id, (prod, available) => new
                        { prod, available })
                    .Join(prices, c => c.prod.Id, p => p.Id, (combined, price) =>
                        new
                        {
                            id = combined.prod.Id, brand = combined.prod.Brand, stock = combined.available.StockStatus,
                            cost = price.OriginalPrice
                        })
                    .Select(i => $"Brand: {i.brand} Id: {i.id} Cost: {i.cost} StockStatus: {i.stock}");
        }

        public static IEnumerable<string> CombinedData(
            IEnumerable<ProductInfo> products,
            IEnumerable<AvailabilitiesInfo> availabilities,
            IEnumerable<PriceInfo> prices
            )
        {
            return products
                    .Join(
                        JoinPriceAndAvailabilities(availabilities, prices),
                        f => f.Id,
                        c => c.Id,
                        (fullProd, combined) => new 
                        {
                            ProductId = fullProd.Id,
                            fullProd.Name,
                            fullProd.Brand,
                            CombinedProduct = new
                            {
                                combined.StoreNumber,
                                combined.Available,
                                combined.StockStatus,
                                combined.OriginalPrice,
                                combined.HasPrice
                            }
                        })
                    .GroupBy(h => new { h.ProductId, h.Name, h.Brand })
                    .Select(g => $"Id: {g.Key.ProductId} Brand: {g.Key.Brand} Name: {g.Key.Name} {string.Join(" ", g.Select(c =>
                        $"{c.CombinedProduct.StoreNumber}_Available: {c.CombinedProduct.Available} " +
                        $"{c.CombinedProduct.StoreNumber}_StockStatus: {c.CombinedProduct.StockStatus} " +
                        $"{c.CombinedProduct.StoreNumber}_OriginalPrice: {c.CombinedProduct.OriginalPrice} " +
                        $"{c.CombinedProduct.StoreNumber}_HasPrice: {c.CombinedProduct.HasPrice} "))}"
                    ).ToList();
        }

        private static IEnumerable<CombinedProduct> JoinPriceAndAvailabilities(IEnumerable<AvailabilitiesInfo> availabilities, IEnumerable<PriceInfo> prices)
        {
            return availabilities.Join(prices,
                a => new { Id = a.id, a.StoreNumber },
                p => new { p.Id, p.StoreNumber },
                (available, price) => new CombinedProduct()
                {
                    StoreNumber = available.StoreNumber,
                    StockStatus = available.StockStatus,
                    Available = available.Available,
                    OriginalPrice = price.OriginalPrice,
                    HasPrice = price.HasPrice,
                    Id = available.id
                }).ToArray();
        }
    }
}
