using shop.CoreBusiness;
using shop.Plugins.EFCore;
using shop.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.UseCases
{
    public class LoadOrderUseCase : ILoadOrderUseCase
    {
        private readonly IOrderRepository orderRepository;

        public LoadOrderUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task <List<Order>> EcecuteAsync()
        {
            return await orderRepository.LoadOrders();
        }
    }
}
