using shop.CoreBusiness;

namespace shop.UseCases.Interfaces
{
    public interface ILoadProductsUseCase
    {
        Task<List<Products>> ExecuteAsync();
    }
}