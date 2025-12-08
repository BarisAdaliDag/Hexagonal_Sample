using HexagonalSample.Application.DtoClasses.Categories;
using HexagonalSample.Application.PrimaryPorts.CategoryPorts;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.Enum;
using HexagonalSample.Domain.SecondaryPorts;

namespace HexagonalSample.Application.UseCases.CategoryUseCases
{
    
    public class CreateCategoryUseCase : ICreateCategoryUseCase
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryUseCase(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(CreateCategoryDto dto)
        {
            Category category = new()
            {
                CategoryName = dto.Name,
                Description = dto.Description,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            await _repository.CreateAsync(category);
        }
    }

    // GET ALL
    public class GetAllCategoriesUseCase : IGetAllCategoriesUseCase
    {
        private readonly ICategoryRepository _repository;

        public GetAllCategoriesUseCase(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Category>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }

    // GET BY ID
    public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryByIdUseCase(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> ExecuteAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }

    // UPDATE
    public class UpdateCategoryUseCase : IUpdateCategoryUseCase
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryUseCase(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(UpdateCategoryDto dto)
        {
            var category = await _repository.GetByIdAsync(dto.Id);
            
            if (category != null)
            {
                category.CategoryName = dto.Name;
                category.Description = dto.Description;
                await _repository.UpdateAsync(category);
            }
        }
    }

    // DELETE
    public class DeleteCategoryUseCase : IDeleteCategoryUseCase
    {
        private readonly ICategoryRepository _repository;

        public DeleteCategoryUseCase(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
