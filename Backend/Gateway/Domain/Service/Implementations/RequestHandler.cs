using ECommerceAPIGateway.Domain.Service.Factories;
using ECommerceAPIGateway.Domain.Service.Interfaces;
using ECommerceUserAPI;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace ECommerceAPIGateway.Domain.Service.Implementations
{
    public class RequestHandler : IRequestHandler
    {
        private readonly RequestFactory _requestFactory;
        public RequestHandler(RequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        public async Task<string> SendRequest(dynamic? body, string service, string endpoint, string httpMethod)
        {
            return await _requestFactory.SendRequest(service, endpoint, body, httpMethod);
        }
    }
}
