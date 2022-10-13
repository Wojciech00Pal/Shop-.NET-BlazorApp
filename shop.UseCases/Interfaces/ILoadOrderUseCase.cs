using shop.CoreBusiness;

namespace shop.UseCases.Interfaces
{
    public interface ILoadOrderUseCase
    {
        Task <List<Order>> EcecuteAsync();
    }
}