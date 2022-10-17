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
    public class GetOrderByIdUseCase : IGetOrderByIdUseCase
    {
        private readonly IOrderRepository orderRepository;

        public GetOrderByIdUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }


        public async Task<Order> ExecuteAsync(int ordId)
        {
            return await orderRepository.GetOrderbyId(ordId);
        }
    }
}
