using HexagonalSample.Application.DtoClasses.Products;
using HexagonalSample.Domain.Entities;

namespace HexagonalSample.Application.PrimaryPorts.ProductPorts
{
    public interface ICreateProductUseCase
    {
        Task ExecuteAsync(CreateProductDto dto);
    }

    public interface IGetAllProductsUseCase
    {
        Task<List<Product>> ExecuteAsync();
    }

    public interface IGetProductByIdUseCase
    {
        Task<Product> ExecuteAsync(int id);
    }

    public interface IUpdateProductUseCase
    {
        Task ExecuteAsync(UpdateProductDto dto);
    }

    public interface IDeleteProductUseCase
    {
        Task ExecuteAsync(int id);
    }
}
