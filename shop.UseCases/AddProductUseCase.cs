using shop.UseCases.Interfaces;
using shop.UseCases.pluginInterfaces;

namespace shop.UseCases
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductRepository productRepository;

        public AddProductUseCase(IProductRepository ProductRepository)
        {
            productRepository = ProductRepository;
        }

        public async Task ExecuteAsync(int id, int qty)
        {
            await productRepository.AddAsync(id, qty);

        }
    }
}