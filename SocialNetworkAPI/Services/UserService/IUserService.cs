namespace SocialNetworkAPI.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDto>>> GetAllUsers();
        Task<ServiceResponse<GetUserDto>> GetUserById(int id);
        Task<ServiceResponse<GetUserDto>> AddUser(AddUserDto request);
        Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto request);
        Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id);
    }
}
