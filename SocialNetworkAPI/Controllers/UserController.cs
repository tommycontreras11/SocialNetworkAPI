using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> Get() 
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Get(int id)
        {
            var response = await _userService.GetUserById(id);
            if (response is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> Post(AddUserDto request)
        {
            return Ok(await _userService.AddUser(request));
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Put(UpdateUserDto request)
        {
            var response = await _userService.UpdateUser(request);
            if (response is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> Delete(int id)
        {
            var response = await _userService.DeleteUser(id);
            if (response is null)
                return NotFound(response);

            return Ok(response);
        }
    }
}
