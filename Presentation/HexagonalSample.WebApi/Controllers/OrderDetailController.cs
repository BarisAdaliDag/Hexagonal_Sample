using HexagonalSample.Application.DtoClasses.OrderDetails;
using HexagonalSample.Application.PrimaryPorts.OrderDetailPorts;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly ICreateOrderDetailUseCase _createOrderDetailUseCase;
        private readonly IGetAllOrderDetailsUseCase _getAllOrderDetailsUseCase;
        private readonly IGetOrderDetailByIdUseCase _getOrderDetailByIdUseCase;
        private readonly IUpdateOrderDetailUseCase _updateOrderDetailUseCase;
        private readonly IDeleteOrderDetailUseCase _deleteOrderDetailUseCase;

        public OrderDetailController(
            ICreateOrderDetailUseCase createOrderDetailUseCase,
            IGetAllOrderDetailsUseCase getAllOrderDetailsUseCase,
            IGetOrderDetailByIdUseCase getOrderDetailByIdUseCase,
            IUpdateOrderDetailUseCase updateOrderDetailUseCase,
            IDeleteOrderDetailUseCase deleteOrderDetailUseCase)
        {
            _createOrderDetailUseCase = createOrderDetailUseCase;
            _getAllOrderDetailsUseCase = getAllOrderDetailsUseCase;
            _getOrderDetailByIdUseCase = getOrderDetailByIdUseCase;
            _updateOrderDetailUseCase = updateOrderDetailUseCase;
            _deleteOrderDetailUseCase = deleteOrderDetailUseCase;
        }

        // GET: api/OrderDetail
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orderDetails = await _getAllOrderDetailsUseCase.ExecuteAsync();
            return Ok(orderDetails);
        }

        // GET: api/OrderDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var orderDetail = await _getOrderDetailByIdUseCase.ExecuteAsync(id);
            if (orderDetail == null)
                return NotFound($"ID'si {id} olan sipariş detayı bulunamadı.");
            
            return Ok(orderDetail);
        }

        // POST: api/OrderDetail
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDetailDto dto)
        {
            await _createOrderDetailUseCase.ExecuteAsync(dto);
            return Ok("OrderDetail başarıyla oluşturuldu.");
        }

        // PUT: api/OrderDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateOrderDetailDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID uyuşmazlığı.");

            await _updateOrderDetailUseCase.ExecuteAsync(dto);
            return Ok("OrderDetail başarıyla güncellendi.");
        }

        // DELETE: api/OrderDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteOrderDetailUseCase.ExecuteAsync(id);
            return Ok("OrderDetail başarıyla silindi.");
        }
    }
}
