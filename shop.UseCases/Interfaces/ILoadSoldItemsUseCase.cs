using shop.CoreBusiness;

namespace shop.UseCases.Interfaces
{
    public interface ILoadSoldItemsUseCase
    {
        Task<List<SoldItems>> ExecuteAsync();
    }
}