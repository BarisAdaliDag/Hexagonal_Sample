using HexagonalSample.Application.DtoClasses.OrderDetails;
using HexagonalSample.Application.PrimaryPorts.OrderDetailPorts;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.Enum;
using HexagonalSample.Domain.SecondaryPorts;

namespace HexagonalSample.Application.UseCases.OrderDetailUseCases
{
    // CREATE
    public class CreateOrderDetailUseCase : ICreateOrderDetailUseCase
    {
        private readonly IOrderDetailRepository _repository;

        public CreateOrderDetailUseCase(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(CreateOrderDetailDto dto)
        {
            OrderDetail orderDetail = new()
            {
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            await _repository.CreateAsync(orderDetail);
        }
    }

    // GET ALL
    public class GetAllOrderDetailsUseCase : IGetAllOrderDetailsUseCase
    {
        private readonly IOrderDetailRepository _repository;

        public GetAllOrderDetailsUseCase(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<OrderDetail>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }

    // GET BY ID
    public class GetOrderDetailByIdUseCase : IGetOrderDetailByIdUseCase
    {
        private readonly IOrderDetailRepository _repository;

        public GetOrderDetailByIdUseCase(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderDetail> ExecuteAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }

    // UPDATE
    public class UpdateOrderDetailUseCase : IUpdateOrderDetailUseCase
    {
        private readonly IOrderDetailRepository _repository;

        public UpdateOrderDetailUseCase(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(UpdateOrderDetailDto dto)
        {
            var orderDetail = await _repository.GetByIdAsync(dto.Id);
            
            if (orderDetail != null)
            {
                orderDetail.OrderId = dto.OrderId;
                orderDetail.ProductId = dto.ProductId;
                await _repository.UpdateAsync(orderDetail);
            }
        }
    }

    // DELETE
    public class DeleteOrderDetailUseCase : IDeleteOrderDetailUseCase
    {
        private readonly IOrderDetailRepository _repository;

        public DeleteOrderDetailUseCase(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
