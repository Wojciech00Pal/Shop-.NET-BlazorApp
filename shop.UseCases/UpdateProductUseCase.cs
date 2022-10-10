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
    public class UpdateProductUseCase : IUpdateProductUseCase
    {
        private readonly IProductRepository productRepository;

        public UpdateProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task ExecuteAsync(Products prod)
        {
            await productRepository.UpdateProducts(prod);
        }
    }
}
