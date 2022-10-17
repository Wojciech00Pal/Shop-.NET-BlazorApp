using shop.CoreBusiness;

namespace shop.UseCases.Interfaces
{
    public interface IGetOrderByIdUseCase
    {
        Task<Order> ExecuteAsync(int ordId);
    }
}