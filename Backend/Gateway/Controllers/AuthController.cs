using ECommerceAPIGateway.Domain.Service.Implementations;
using ECommerceAPIGateway.Domain.Service.Interfaces;
using ECommerceUserAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPIGateway.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly RequestHandler _requestHandler;
        public AuthenticationController(RequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
        }

        [Route("{service}/{*endpoint}")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] dynamic body, string service, string endpoint)
        {
            Response.ContentType = "application/json";
            return Content(await _requestHandler.SendRequest(body, service, endpoint, "POST"));
        }
        //[HttpPost("sign-in")]
        //public async Task<IActionResult> SignIn([FromBody] LoginModel loginModel)
        //{
        //    try
        //    {
        //        Response.ContentType = "application/json";
        //        return Content(await _authService.SignIn(loginModel));
        //    }
        //    catch (Exception error)
        //    {
        //        return BadRequest(error);
        //    }
        //}

        //[HttpPost("sign-up")]
        //public async Task<IActionResult> SignUp([FromBody] RegisterModel registerModel)
        //{
        //    try
        //    {
        //        return Ok(await _authService.SignUp(registerModel));
        //    } catch (Exception error) 
        //    {
        //        return BadRequest(error);
        //    }
        //}
    }
}