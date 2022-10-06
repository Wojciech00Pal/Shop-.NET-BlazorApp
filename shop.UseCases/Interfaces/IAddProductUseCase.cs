namespace shop.UseCases.Interfaces
{
    public interface IAddProductUseCase
    {
        Task ExecuteAsync(int id, int qty);
    }
}