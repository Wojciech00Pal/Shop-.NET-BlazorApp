using shop.CoreBusiness;

namespace shop.UseCases.Interfaces
{
    public interface IUpdateProductUseCase
    {
        Task ExecuteAsync(Products prod);
    }
}