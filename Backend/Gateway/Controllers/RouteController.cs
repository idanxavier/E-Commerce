using ECommerceAPIGateway.Domain.Service.Implementations;
using ECommerceAPIGateway.Domain.Service.Interfaces;
using ECommerceUserAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPIGateway.Controllers
{
    [ApiController]
    public class RouterController : ControllerBase
    {
        private readonly IRequestHandler _requestHandler;
        public RouterController(IRequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
        }

        [Route("api/{service}/{*endpoint}")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] dynamic body, string service, string endpoint)
        {
            Response.ContentType = "application/json";
            return Content(await _requestHandler.SendRequest(body, service, endpoint, "POST"));
        }

        [Route("api/{service}/{*endpoint}")]
        [HttpGet]
        public async Task<IActionResult> GetAsync(string service, string endpoint)
        {
            Response.ContentType = "application/json";
            return Content(await _requestHandler.SendRequest(new Object(), service, endpoint, "GET"));
        }
    }
}