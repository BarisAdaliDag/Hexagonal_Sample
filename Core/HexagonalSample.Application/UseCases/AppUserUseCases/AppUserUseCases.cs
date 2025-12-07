using HexagonalSample.Application.DtoClasses.AppUsers;
using HexagonalSample.Application.PrimaryPorts.AppUserPorts;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.Enum;
using HexagonalSample.Domain.SecondaryPorts;

namespace HexagonalSample.Application.UseCases.AppUserUseCases
{
    
    public class CreateAppUserUseCase : ICreateAppUserUseCase
    {
        private readonly IAppUserRepository _repository;

        public CreateAppUserUseCase(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(CreateAppUserDto dto)
        {
            AppUser appUser = new()
            {
                UserName = dto.UserName,
                Password = dto.Password,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted,
                AppUserProfile = new AppUserProfile
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                }
            };

            await _repository.CreateAsync(appUser);
        }
    }

   
    public class GetAllAppUsersUseCase : IGetAllAppUsersUseCase
    {
        private readonly IAppUserRepository _repository;

        public GetAllAppUsersUseCase(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AppUser>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }

    
    public class GetAppUserByIdUseCase : IGetAppUserByIdUseCase
    {
        private readonly IAppUserRepository _repository;

        public GetAppUserByIdUseCase(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<AppUser> ExecuteAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }

    
    public class UpdateAppUserUseCase : IUpdateAppUserUseCase
    {
        private readonly IAppUserRepository _repository;

        public UpdateAppUserUseCase(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(UpdateAppUserDto dto)
        {
            var appUser = await _repository.GetByIdAsync(dto.Id);
            
            if (appUser != null)
            {
                appUser.UserName = dto.UserName;
                appUser.Password = dto.Password;
                
                if (appUser.AppUserProfile != null)
                {
                    appUser.AppUserProfile.FirstName = dto.FirstName;
                    appUser.AppUserProfile.LastName = dto.LastName;
                }

                await _repository.UpdateAsync(appUser);
            }
        }
    }

   
    public class DeleteAppUserUseCase : IDeleteAppUserUseCase
    {
        private readonly IAppUserRepository _repository;

        public DeleteAppUserUseCase(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
