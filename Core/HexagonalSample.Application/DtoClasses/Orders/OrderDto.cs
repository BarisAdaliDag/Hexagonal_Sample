namespace HexagonalSample.Application.DtoClasses.Orders
{
    public class OrderDto : BaseDto
    {
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}