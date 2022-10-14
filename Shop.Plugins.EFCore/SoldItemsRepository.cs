using Microsoft.EntityFrameworkCore;
using shop.Plugins.EFCore;

using shop.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.Plugins.EFCore
{
    public class SoldItemsRepository : ISoldItemsRepository
    {
        private readonly shopContext db;

        
        public SoldItemsRepository(shopContext db)
        {
            this.db = db;
        }

        public async Task AddSoldItems(List<Products>? products, double price, int orderId)
        {

            foreach (Products prod in products)
            {
                if (prod != null)
                {
                    var lol = new SoldItems
                    {
                        OrdId = orderId,
                        ProdId = prod.ProductId,
                        Price = price,
                        ProductName = prod.ProductName,
                        Quantity = prod.Quantity,
                        Sum = prod.Sum
                    };
                    await db.SoldItems.AddAsync(lol);
                        
                    //await db.SoldItems.AddAsync(lol);
                    //dodac id bo ma problem z dodaniem do solditems
                }
                //  await db.SoldItems.AddAsync(lol);

            }
            await db.SaveChangesAsync();

            var test = LoadSoldItems();
        }

        public async Task <List<SoldItems>> LoadSoldItems()
        {
            var sold = await db.SoldItems.ToListAsync();
            return sold;
           
        }
    }

}
