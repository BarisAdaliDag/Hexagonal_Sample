using HexagonalSample.Application.DtoClasses.Orders;
using HexagonalSample.Application.PrimaryPorts.OrderPorts;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICreateOrderUseCase _createOrderUseCase;
        private readonly IGetAllOrdersUseCase _getAllOrdersUseCase;
        private readonly IGetOrderByIdUseCase _getOrderByIdUseCase;
        private readonly IUpdateOrderUseCase _updateOrderUseCase;
        private readonly IDeleteOrderUseCase _deleteOrderUseCase;

        public OrderController(
            ICreateOrderUseCase createOrderUseCase,
            IGetAllOrdersUseCase getAllOrdersUseCase,
            IGetOrderByIdUseCase getOrderByIdUseCase,
            IUpdateOrderUseCase updateOrderUseCase,
            IDeleteOrderUseCase deleteOrderUseCase)
        {
            _createOrderUseCase = createOrderUseCase;
            _getAllOrdersUseCase = getAllOrdersUseCase;
            _getOrderByIdUseCase = getOrderByIdUseCase;
            _updateOrderUseCase = updateOrderUseCase;
            _deleteOrderUseCase = deleteOrderUseCase;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _getAllOrdersUseCase.ExecuteAsync();
            return Ok(orders);
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _getOrderByIdUseCase.ExecuteAsync(id);
            if (order == null)
                return NotFound($"ID'si {id} olan sipariş bulunamadı.");
            
            return Ok(order);
        }

        // POST: api/Order
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto dto)
        {
            await _createOrderUseCase.ExecuteAsync(dto);
            return Ok("Order başarıyla oluşturuldu.");
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateOrderDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID uyuşmazlığı.");

            await _updateOrderUseCase.ExecuteAsync(dto);
            return Ok("Order başarıyla güncellendi.");
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteOrderUseCase.ExecuteAsync(id);
            return Ok("Order başarıyla silindi.");
        }
    }
}
