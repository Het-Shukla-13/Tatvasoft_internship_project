using Microsoft.AspNetCore.Mvc;
using MyProject.Entities.ViewModels.Login;
using MyProject.Entities.ViewModels;
using MyProject.Services.IService;
using Microsoft.AspNetCore.Authorization;

namespace MyProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("LoginUser")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginRequestModel model)
        {
            var response = await _userService.LoginUser(model);

            if (response.Result == ResponseStatus.Error)
                return Unauthorized(response);

            return Ok(response);
        }
    }
}
