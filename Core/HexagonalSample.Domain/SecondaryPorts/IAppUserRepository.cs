using HexagonalSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Domain.SecondaryPorts
{
    public interface IAppUserRepository
    {
        Task<List<AppUser>> GetAllAsync();
        Task<AppUser> GetByIdAsync(int id);
        Task CreateAsync(AppUser appUser);
        Task UpdateAsync(AppUser appUser);
        Task DeleteAsync(int id);
    }
}
