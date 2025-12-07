namespace HexagonalSample.Application.DtoClasses.Products
{
    public class ProductDto : BaseDto
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
    }
}