using shop.CoreBusiness;

namespace shop.Plugins.EFCore
{
    public interface IOrderRepository
    {
        Task AddOrder(List<Products>? products);
        int GetId();
    }
}