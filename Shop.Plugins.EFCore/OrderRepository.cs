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

        public OrderRepository(shopContext db)
        {
            this.db = db;
        }

        public async Task AddOrder(List<Products>? products)
        {
            var order = new Order
            {
                OrderId = GetId(),
                ProductList = products,
                Date = DateTime.Now
            };
            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
        }

        public int GetId()
        {
            int val = 1 + this.db.Orders.Count();
            return val;
        }
    }
}
