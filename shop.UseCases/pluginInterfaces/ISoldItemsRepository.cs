using shop.CoreBusiness;

namespace shop.Plugins.EFCore
{
    public interface ISoldItemsRepository
    {
        Task AddSoldItems(List<Products>? products, double price, int orderId);

        Task<List<SoldItems>> LoadSoldItems();
    }
}