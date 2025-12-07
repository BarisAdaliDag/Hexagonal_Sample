using HexagonalSample.Application.DtoClasses.Orders;
using HexagonalSample.Domain.Entities;

namespace HexagonalSample.Application.PrimaryPorts.OrderPorts
{
    public interface ICreateOrderUseCase
    {
        Task ExecuteAsync(CreateOrderDto dto);
    }

    public interface IGetAllOrdersUseCase
    {
        Task<List<Order>> ExecuteAsync();
    }

    public interface IGetOrderByIdUseCase
    {
        Task<Order> ExecuteAsync(int id);
    }

    public interface IUpdateOrderUseCase
    {
        Task ExecuteAsync(UpdateOrderDto dto);
    }

    public interface IDeleteOrderUseCase
    {
        Task ExecuteAsync(int id);
    }
}
