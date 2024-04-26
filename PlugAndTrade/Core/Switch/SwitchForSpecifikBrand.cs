using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugAndTrade.Core.Switch
{
    public class SwitchForSpecifikBrand
    {
                           
        public static void SwitchWithDifferentBrands(IEnumerable<ProductInfo> list, string choosenBrand)
        {
            
            var specifikBrand = list.GroupBy(b => b.Brand == choosenBrand, b => b.Id ,(brandName , brandId) => new
            {
                Key = brandName,
                id = string.Join(',', brandId)
            } );
            
            foreach (var brand in specifikBrand)
            {
                Console.WriteLine(brand.Key);
                Console.WriteLine($"Brand: {brand.id}");
            }
        }
    }
}
