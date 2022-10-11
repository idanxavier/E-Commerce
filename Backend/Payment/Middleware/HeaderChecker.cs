namespace ECommercePaymentAPI.Middleware
{
    public class HeaderChecker
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public HeaderChecker(RequestDelegate next, IConfiguration configuration) 
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey(_configuration["HeaderSecret"]))
                context.Response.StatusCode = 400;
            else
                await _next.Invoke(context);
        }
    }
}
