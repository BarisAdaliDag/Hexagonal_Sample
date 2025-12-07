using HexagonalSample.Application.DtoClasses.Categories;
using HexagonalSample.Domain.Entities;

namespace HexagonalSample.Application.PrimaryPorts.CategoryPorts
{
    public interface ICreateCategoryUseCase
    {
        Task ExecuteAsync(CreateCategoryDto dto);
    }

    public interface IGetAllCategoriesUseCase
    {
        Task<List<Category>> ExecuteAsync();
    }

    public interface IGetCategoryByIdUseCase
    {
        Task<Category> ExecuteAsync(int id);
    }

    public interface IUpdateCategoryUseCase
    {
        Task ExecuteAsync(UpdateCategoryDto dto);
    }

    public interface IDeleteCategoryUseCase
    {
        Task ExecuteAsync(int id);
    }
}
