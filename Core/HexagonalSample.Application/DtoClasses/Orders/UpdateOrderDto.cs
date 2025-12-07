namespace HexagonalSample.Application.DtoClasses.Orders
{
    public class UpdateOrderDto : BaseDto
    {
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}
