using shop.CoreBusiness;

namespace shop.UseCases.Interfaces
{
    public interface IAddOrderUseCase
    {
        Task ExecuteAsync(List<Products>? prods);
    }
}