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

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] RegisterModel model)
        {
            try {
                IdentityUser newUser = await _authService.SignUp(model);
                return Ok(newUser);
            } 
            catch (Exception error){
                throw error;
            }
        }
    }
}