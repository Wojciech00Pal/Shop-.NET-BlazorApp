using shop.CoreBusiness;
using shop.UseCases.Interfaces;
using shop.UseCases.pluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.UseCases
{
    public class LoadProductsUseCase : ILoadProductsUseCase
    {
        private readonly IProductRepository productRepository;

        public LoadProductsUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<List<Products>> ExecuteAsync()
        {
            return await productRepository.LoadProducts();
        }

    }
}
