using HexagonalSample.Application.DtoClasses.AppUsers;
using HexagonalSample.Application.PrimaryPorts.AppUserPorts;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly ICreateAppUserUseCase _createAppUserUseCase;
        private readonly IGetAllAppUsersUseCase _getAllAppUsersUseCase;
        private readonly IGetAppUserByIdUseCase _getAppUserByIdUseCase;
        private readonly IUpdateAppUserUseCase _updateAppUserUseCase;
        private readonly IDeleteAppUserUseCase _deleteAppUserUseCase;

        public AppUserController(
            ICreateAppUserUseCase createAppUserUseCase,
            IGetAllAppUsersUseCase getAllAppUsersUseCase,
            IGetAppUserByIdUseCase getAppUserByIdUseCase,
            IUpdateAppUserUseCase updateAppUserUseCase,
            IDeleteAppUserUseCase deleteAppUserUseCase)
        {
            _createAppUserUseCase = createAppUserUseCase;
            _getAllAppUsersUseCase = getAllAppUsersUseCase;
            _getAppUserByIdUseCase = getAppUserByIdUseCase;
            _updateAppUserUseCase = updateAppUserUseCase;
            _deleteAppUserUseCase = deleteAppUserUseCase;
        }

        // GET: api/AppUser
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var appUsers = await _getAllAppUsersUseCase.ExecuteAsync();
            return Ok(appUsers);
        }

        // GET: api/AppUser/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var appUser = await _getAppUserByIdUseCase.ExecuteAsync(id);
            if (appUser == null)
                return NotFound($"ID'si {id} olan kullanıcı bulunamadı.");
            
            return Ok(appUser);
        }

        // POST: api/AppUser
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAppUserDto dto)
        {
            await _createAppUserUseCase.ExecuteAsync(dto);
            return Ok("AppUser başarıyla oluşturuldu.");
        }

        // PUT: api/AppUser/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAppUserDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID uyuşmazlığı.");

            await _updateAppUserUseCase.ExecuteAsync(dto);
            return Ok("AppUser başarıyla güncellendi.");
        }

        // DELETE: api/AppUser/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteAppUserUseCase.ExecuteAsync(id);
            return Ok("AppUser başarıyla silindi.");
        }
    }
}
