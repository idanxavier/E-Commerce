using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceUserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] RegisterModel model)
        {
            try {
                IdentityUser newUser = await _authService.SignUp(model);
                return Ok(newUser);
            } 
            catch (Exception error){
                return BadRequest(error.Message);
            }
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] LoginModel model) {
            try {
                UserDTO user = await _authService.SignIn(model);
                return Ok(user);
            } 
            catch (Exception error){
                return BadRequest(error.Message);
            }
        }
    }
}