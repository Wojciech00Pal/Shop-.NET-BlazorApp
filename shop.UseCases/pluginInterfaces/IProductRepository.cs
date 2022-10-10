using shop.CoreBusiness;

namespace shop.UseCases.pluginInterfaces
{
    public interface IProductRepository
    {
        Task AddAsync(int productId, int quantity);
        Task<ProductStorage> GetStorageProductById(int id);
        Task<List<Products>> LoadProducts();

        Task UpdateProducts(Products pr);
    }
}