using HexagonalSample.Domain.Entities;

namespace HexagonalSample.Domain.SecondaryPorts
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetail>> GetAllAsync();
        Task<OrderDetail> GetByIdAsync(int id);
        Task CreateAsync(OrderDetail orderDetail);
        Task UpdateAsync(OrderDetail orderDetail);
        Task DeleteAsync(int id);
    }
}
