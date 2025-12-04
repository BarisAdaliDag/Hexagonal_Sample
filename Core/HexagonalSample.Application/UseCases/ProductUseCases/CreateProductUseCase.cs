using HexagonalSample.Application.DtoClasses.Products;
using HexagonalSample.Application.PrimaryPorts.ProductPorts;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.ProductUseCases
{
    public class CreateProductUseCase : ICreateProductUseCase
    {
        private readonly IProductRepository _repository;

        public CreateProductUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(CreateProductCommand command)
        {
            Product product = new Product()
            {
                ProductName = command.Name,
                UnitPrice = command.Price,
                CreatedDate = DateTime.Now
            };
           
            await _repository.CreateAsync(product);
        }
    }
}
