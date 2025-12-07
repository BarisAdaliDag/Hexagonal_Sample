namespace HexagonalSample.Application.DtoClasses.OrderDetails
{
    public class UpdateOrderDetailDto : BaseDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
