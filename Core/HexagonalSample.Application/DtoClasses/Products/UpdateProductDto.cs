namespace HexagonalSample.Application.DtoClasses.Products
{
    public class UpdateProductDto : BaseDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
    }
}
