using shop.CoreBusiness;
using shop.UseCases.pluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.UseCases
{
    public class AddProdToOrderUseCase
    {
        private readonly IProductRepository productRepository;

        public AddProdToOrderUseCase(IProductRepository productRepository )
        {
            this.productRepository = productRepository;
        }


        public async Task EcecuteAsync(int id)
        {
            //set order_id to products
            await productRepository.AddProdToOrder(id);
        }

    }
}
