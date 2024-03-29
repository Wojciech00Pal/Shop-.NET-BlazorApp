﻿using Microsoft.EntityFrameworkCore;
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

        public async Task AddSoldItems(List<Products>? products, double price)
        {

            foreach (Products prod in products)
            {
                if (prod != null)
                {
                    db.Products.Remove(prod);
                    var lol = new SoldItems
                    {
                        OrdId = db.Orders.Count(),
                        ProdId = prod.ProductId,
                        Price = price,
                        ProductName = prod.ProductName,
                        Quantity = prod.Quantity,
                        Sum = prod.Sum
                    };
                    await db.SoldItems.AddAsync(lol);
                   
                }
                //  await db.SoldItems.AddAsync(lol);

            }
         
            await db.SaveChangesAsync();
        }
        public async Task <List<SoldItems>> LoadSoldItems(int id)
        {
            var sold = await db.SoldItems.Where(x=>x.OrdId==id).
            ToListAsync();
            return sold;
           
        }
    }

}
