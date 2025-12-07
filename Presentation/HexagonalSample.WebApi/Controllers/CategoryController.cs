using HexagonalSample.Application.DtoClasses.Categories;
using HexagonalSample.Application.PrimaryPorts.CategoryPorts;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICreateCategoryUseCase _createCategoryUseCase;
        private readonly IGetAllCategoriesUseCase _getAllCategoriesUseCase;
        private readonly IGetCategoryByIdUseCase _getCategoryByIdUseCase;
        private readonly IUpdateCategoryUseCase _updateCategoryUseCase;
        private readonly IDeleteCategoryUseCase _deleteCategoryUseCase;

        public CategoryController(
            ICreateCategoryUseCase createCategoryUseCase,
            IGetAllCategoriesUseCase getAllCategoriesUseCase,
            IGetCategoryByIdUseCase getCategoryByIdUseCase,
            IUpdateCategoryUseCase updateCategoryUseCase,
            IDeleteCategoryUseCase deleteCategoryUseCase)
        {
            _createCategoryUseCase = createCategoryUseCase;
            _getAllCategoriesUseCase = getAllCategoriesUseCase;
            _getCategoryByIdUseCase = getCategoryByIdUseCase;
            _updateCategoryUseCase = updateCategoryUseCase;
            _deleteCategoryUseCase = deleteCategoryUseCase;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _getAllCategoriesUseCase.ExecuteAsync();
            return Ok(categories);
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _getCategoryByIdUseCase.ExecuteAsync(id);
            if (category == null)
                return NotFound($"ID'si {id} olan kategori bulunamadı.");
            
            return Ok(category);
        }

        // POST: api/Category
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
        {
            await _createCategoryUseCase.ExecuteAsync(dto);
            return Ok("Category başarıyla oluşturuldu.");
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID uyuşmazlığı.");

            await _updateCategoryUseCase.ExecuteAsync(dto);
            return Ok("Category başarıyla güncellendi.");
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteCategoryUseCase.ExecuteAsync(id);
            return Ok("Category başarıyla silindi.");
        }
    }
}
