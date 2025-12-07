using HexagonalSample.Application.DtoClasses.OrderDetails;
using HexagonalSample.Domain.Entities;

namespace HexagonalSample.Application.PrimaryPorts.OrderDetailPorts
{
    public interface ICreateOrderDetailUseCase
    {
        Task ExecuteAsync(CreateOrderDetailDto dto);
    }

    public interface IGetAllOrderDetailsUseCase
    {
        Task<List<OrderDetail>> ExecuteAsync();
    }

    public interface IGetOrderDetailByIdUseCase
    {
        Task<OrderDetail> ExecuteAsync(int id);
    }

    public interface IUpdateOrderDetailUseCase
    {
        Task ExecuteAsync(UpdateOrderDetailDto dto);
    }

    public interface IDeleteOrderDetailUseCase
    {
        Task ExecuteAsync(int id);
    }
}
