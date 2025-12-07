namespace HexagonalSample.Application.DtoClasses.Orders
{
    public class CreateOrderDto
    {
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}
