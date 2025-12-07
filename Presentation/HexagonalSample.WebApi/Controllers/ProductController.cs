using HexagonalSample.Application.DtoClasses.Products;
using HexagonalSample.Application.PrimaryPorts.ProductPorts;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICreateProductUseCase _createProductUseCase;
        private readonly IGetAllProductsUseCase _getAllProductsUseCase;
        private readonly IGetProductByIdUseCase _getProductByIdUseCase;
        private readonly IUpdateProductUseCase _updateProductUseCase;
        private readonly IDeleteProductUseCase _deleteProductUseCase;

        public ProductController(
            ICreateProductUseCase createProductUseCase,
            IGetAllProductsUseCase getAllProductsUseCase,
            IGetProductByIdUseCase getProductByIdUseCase,
            IUpdateProductUseCase updateProductUseCase,
            IDeleteProductUseCase deleteProductUseCase)
        {
            _createProductUseCase = createProductUseCase;
            _getAllProductsUseCase = getAllProductsUseCase;
            _getProductByIdUseCase = getProductByIdUseCase;
            _updateProductUseCase = updateProductUseCase;
            _deleteProductUseCase = deleteProductUseCase;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _getAllProductsUseCase.ExecuteAsync();
            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _getProductByIdUseCase.ExecuteAsync(id);
            if (product == null)
                return NotFound($"ID'si {id} olan ürün bulunamadı.");
            
            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            await _createProductUseCase.ExecuteAsync(dto);
            return Ok("Product başarıyla oluşturuldu.");
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID uyuşmazlığı.");

            await _updateProductUseCase.ExecuteAsync(dto);
            return Ok("Product başarıyla güncellendi.");
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteProductUseCase.ExecuteAsync(id);
            return Ok("Product başarıyla silindi.");
        }
    }
}
