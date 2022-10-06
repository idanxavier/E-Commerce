using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommercePaymentAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        public PaymentController()
        {
        }

        [HttpGet(Name = "teste")]
        public string Get()
        {
            return "OI";
        }
    }
}