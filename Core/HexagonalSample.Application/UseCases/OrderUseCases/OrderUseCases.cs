using HexagonalSample.Application.DtoClasses.Orders;
using HexagonalSample.Application.PrimaryPorts.OrderPorts;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.Enum;
using HexagonalSample.Domain.SecondaryPorts;

namespace HexagonalSample.Application.UseCases.OrderUseCases
{
    // CREATE
    public class CreateOrderUseCase : ICreateOrderUseCase
    {
        private readonly IOrderRepository _repository;

        public CreateOrderUseCase(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(CreateOrderDto dto)
        {
            Order order = new()
            {
                ShippingAddress = dto.ShippingAddress,
                AppUserId = dto.AppUserId,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            await _repository.CreateAsync(order);
        }
    }

    // GET ALL
    public class GetAllOrdersUseCase : IGetAllOrdersUseCase
    {
        private readonly IOrderRepository _repository;

        public GetAllOrdersUseCase(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Order>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }

    // GET BY ID
    public class GetOrderByIdUseCase : IGetOrderByIdUseCase
    {
        private readonly IOrderRepository _repository;

        public GetOrderByIdUseCase(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Order> ExecuteAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }

    // UPDATE
    public class UpdateOrderUseCase : IUpdateOrderUseCase
    {
        private readonly IOrderRepository _repository;

        public UpdateOrderUseCase(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(UpdateOrderDto dto)
        {
            var order = await _repository.GetByIdAsync(dto.Id);
            
            if (order != null)
            {
                order.ShippingAddress = dto.ShippingAddress;
                order.AppUserId = dto.AppUserId;
                await _repository.UpdateAsync(order);
            }
        }
    }

    // DELETE
    public class DeleteOrderUseCase : IDeleteOrderUseCase
    {
        private readonly IOrderRepository _repository;

        public DeleteOrderUseCase(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
