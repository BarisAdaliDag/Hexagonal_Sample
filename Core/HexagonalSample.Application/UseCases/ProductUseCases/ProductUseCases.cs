using HexagonalSample.Application.DtoClasses.Products;
using HexagonalSample.Application.PrimaryPorts.ProductPorts;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.Enum;
using HexagonalSample.Domain.SecondaryPorts;

namespace HexagonalSample.Application.UseCases.ProductUseCases
{
    // CREATE
    public class CreateProductUseCase : ICreateProductUseCase
    {
        private readonly IProductRepository _repository;

        public CreateProductUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(CreateProductDto dto)
        {
            Product product = new()
            {
                ProductName = dto.Name,
                UnitPrice = dto.Price,
                CategoryId = dto.CategoryId,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            await _repository.CreateAsync(product);
        }
    }

    // GET ALL
    public class GetAllProductsUseCase : IGetAllProductsUseCase
    {
        private readonly IProductRepository _repository;

        public GetAllProductsUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }

    // GET BY ID
    public class GetProductByIdUseCase : IGetProductByIdUseCase
    {
        private readonly IProductRepository _repository;

        public GetProductByIdUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> ExecuteAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }

    // UPDATE
    public class UpdateProductUseCase : IUpdateProductUseCase
    {
        private readonly IProductRepository _repository;

        public UpdateProductUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(UpdateProductDto dto)
        {
            var product = await _repository.GetByIdAsync(dto.Id);
            
            if (product != null)
            {
                product.ProductName = dto.Name;
                product.UnitPrice = dto.Price;
                product.CategoryId = dto.CategoryId;
                await _repository.UpdateAsync(product);
            }
        }
    }

    // DELETE
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository _repository;

        public DeleteProductUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
