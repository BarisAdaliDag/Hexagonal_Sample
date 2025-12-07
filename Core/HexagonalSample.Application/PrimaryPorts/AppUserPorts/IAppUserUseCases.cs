using HexagonalSample.Application.DtoClasses.AppUsers;
using HexagonalSample.Domain.Entities;

namespace HexagonalSample.Application.PrimaryPorts.AppUserPorts
{
    public interface ICreateAppUserUseCase
    {
        Task ExecuteAsync(CreateAppUserDto dto);
    }

    public interface IGetAllAppUsersUseCase
    {
        Task<List<AppUser>> ExecuteAsync();
    }

    public interface IGetAppUserByIdUseCase
    {
        Task<AppUser> ExecuteAsync(int id);
    }

    public interface IUpdateAppUserUseCase
    {
        Task ExecuteAsync(UpdateAppUserDto dto);
    }

    public interface IDeleteAppUserUseCase
    {
        Task ExecuteAsync(int id);
    }
}
