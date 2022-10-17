using Microsoft.EntityFrameworkCore;
using shop.CoreBusiness;
using shop.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.Plugins.EFCore
{
    public class OrderRepository : IOrderRepository
    {
        
        private readonly shopContext db;
        private List<Order> Smartorders;
        
        public OrderRepository(shopContext db)
        {
            this.db = db;
        }

        public async Task AddOrder(List<Products>? products,double price)
        {
            if (products != null)
            {
                var order = new Order
                {
                    Price = price,
                    Date = DateTime.Now
                };
                //await AddSoldItems(products, order.Price, order.OrderId);
                await db.Orders.AddAsync(order);
                await db.SaveChangesAsync();
               // this.Smartorders = await this.db.Orders.ToListAsync();
               var count = await db.Orders.CountAsync();
                
            }
        }

        public async Task<Order> GetOrderbyId(int ordId)
        {
            return await this.db.Orders.FindAsync(ordId);
        }

        public async Task<List<Order>> LoadOrders()
        {
            //zrobic to jako zwracany ustawiony dobrze
           // return this.Smartorders; nie takkk
            //return await this.db.Products.ToListAsync();
             var orders = await this.db.Orders.ToListAsync();//not shown these without  active==true
             return orders; 
        }
    }
}
