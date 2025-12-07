namespace HexagonalSample.Application.DtoClasses.AppUsers
{
    public class UpdateAppUserDto : BaseDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
