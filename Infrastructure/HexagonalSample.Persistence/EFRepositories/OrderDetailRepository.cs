using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.Enum;
using HexagonalSample.Domain.SecondaryPorts;
using HexagonalSample.Persistence.EFData;
using Microsoft.EntityFrameworkCore;

namespace HexagonalSample.Persistence.EFRepositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly MyContext _context;

        public OrderDetailRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDetail>> GetAllAsync()
        {
            return await _context.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Product)
                .Where(od => od.Status != DataStatus.Deleted)
                .ToListAsync();
        }

        public async Task<OrderDetail> GetByIdAsync(int id)
        {
            return await _context.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Product)
                .FirstOrDefaultAsync(od => od.Id == id && od.Status != DataStatus.Deleted);
        }

        public async Task CreateAsync(OrderDetail orderDetail)
        {
            await _context.OrderDetails.AddAsync(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderDetail orderDetail)
        {
            orderDetail.UpdatedDate = DateTime.Now;
            orderDetail.Status = DataStatus.Updated;
            _context.OrderDetails.Update(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail != null)
            {
                orderDetail.DeletedDate = DateTime.Now;
                orderDetail.Status = DataStatus.Deleted;
                await _context.SaveChangesAsync();
            }
        }
    }
}
