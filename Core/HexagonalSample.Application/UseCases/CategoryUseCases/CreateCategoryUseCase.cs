using HexagonalSample.Application.DtoClasses.Categories;
using HexagonalSample.Application.PrimaryPorts.CategoryPorts;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.CategoryUseCases
{
    public class CreateCategoryUseCase : ICreateCategoryUseCase
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryUseCase(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(CreateCategoryCommand command)
        {
            Category category = new()
            {
                CategoryName = command.Name,
                Description = command.Description
            };

            category.CreatedDate = DateTime.Now;
            await _repository.CreateAsync(category);
        }
    }
}
