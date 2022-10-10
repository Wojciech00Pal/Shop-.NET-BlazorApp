using shop.CoreBusiness;
using shop.Plugins.EFCore;
using shop.UseCases.Interfaces;
using shop.UseCases.pluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.UseCases
{
    public class AddOrderUseCase : IAddOrderUseCase
    {
        private readonly IOrderRepository orderRepository;

        public AddOrderUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public async Task ExecuteAsync(List<Products>? prods)
        {
            await orderRepository.AddOrder(prods);

        }
    }
}
