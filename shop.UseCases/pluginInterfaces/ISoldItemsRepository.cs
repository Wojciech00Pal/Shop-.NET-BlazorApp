using shop.CoreBusiness;

namespace shop.Plugins.EFCore
{
    public interface ISoldItemsRepository
    {
        Task AddSoldItems(List<Products>? products, double price);

        Task<List<SoldItems>> LoadSoldItems(int id);
    }
}