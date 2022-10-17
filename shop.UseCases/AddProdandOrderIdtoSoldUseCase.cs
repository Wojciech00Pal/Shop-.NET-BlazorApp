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
    public class AddProdandOrderIdtoSoldUseCase : IAddProdandOrderIdtoSoldUseCase
    {
        private readonly ISoldItemsRepository soldItemsRepository;

        public AddProdandOrderIdtoSoldUseCase(ISoldItemsRepository soldItemsRepository)
        {
            this.soldItemsRepository = soldItemsRepository;
        }


        public async Task EcecuteAsync(List<Products>? products, double price)
        {
            //set order_id to products
            await soldItemsRepository.AddSoldItems(products, price);
        }

    }
}
