using Shop.CoreBusiness;

namespace Shop.Plugins.EFCore
{
    public interface IProductRepository
    {
        Task AddAsync(int productId, int quantity);
        Task<ProductStorage> GetStorageProductById(int id);
    }
}