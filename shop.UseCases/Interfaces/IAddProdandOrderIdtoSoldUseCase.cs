using shop.CoreBusiness;

namespace shop.UseCases.Interfaces
{
    public interface IAddProdandOrderIdtoSoldUseCase
    {
        Task EcecuteAsync(List<Products>? products, double price, int orderId);
    }
}