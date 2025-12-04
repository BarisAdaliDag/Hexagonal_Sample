using HexagonalSample.Application.DtoClasses.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.ProductPorts
{
    public interface ICreateProductUseCase
    {
        Task ExecuteAsync(CreateProductCommand command);

    }
}
