using shop.CoreBusiness;
using System.Diagnostics;

namespace shop.Plugins.EFCore
{
    public interface IOrderRepository
    {
        Task AddOrder(List<Products>? products,double price);
        int GetId();

        Task <List<Order>> LoadOrders();
    }
}