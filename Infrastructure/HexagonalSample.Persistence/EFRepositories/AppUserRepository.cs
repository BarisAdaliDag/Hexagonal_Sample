using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.Enum;
using HexagonalSample.Domain.SecondaryPorts;
using HexagonalSample.Persistence.EFData;
using Microsoft.EntityFrameworkCore;

namespace HexagonalSample.Persistence.EFRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly MyContext _context;

        public AppUserRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<List<AppUser>> GetAllAsync()
        {
            return await _context.AppUsers
                .Include(a => a.AppUserProfile)
                .Where(a => a.Status != DataStatus.Deleted)
                .ToListAsync();
        }

        public async Task<AppUser> GetByIdAsync(int id)
        {
            return await _context.AppUsers
                .Include(a => a.AppUserProfile)
                .FirstOrDefaultAsync(a => a.Id == id && a.Status != DataStatus.Deleted);
        }

        public async Task CreateAsync(AppUser appUser)
        {
            await _context.AppUsers.AddAsync(appUser);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AppUser appUser)
        {
            appUser.UpdatedDate = DateTime.Now;
            appUser.Status = DataStatus.Updated;
            _context.AppUsers.Update(appUser);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var appUser = await _context.AppUsers.FindAsync(id);
            if (appUser != null)
            {
                appUser.DeletedDate = DateTime.Now;
                appUser.Status = DataStatus.Deleted;
                await _context.SaveChangesAsync();
            }
        }
    }
}
