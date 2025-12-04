using HexagonalSample.Application.DtoClasses.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.CategoryPorts
{
    public interface ICreateCategoryUseCase
    {
        Task ExecuteAsync(CreateCategoryCommand command);
    }
}
