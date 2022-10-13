using Microsoft.EntityFrameworkCore;
using shop.CoreBusiness;
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
            var order = new Order
            {
                OrderId = GetId(),
                ProductList = products,
                Price = price,
                Date = DateTime.Now
            };

            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
            this.Smartorders = await this.db.Orders.ToListAsync();
    

        }

        public int GetId()
        {
            int val = 1 + this.db.Orders.Count();
            return val;
            var test = LoadOrders();
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
