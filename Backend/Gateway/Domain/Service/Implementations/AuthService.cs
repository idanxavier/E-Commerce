using ECommerceAPIGateway.Domain.Service.Factories;
using ECommerceAPIGateway.Domain.Service.Interfaces;
using ECommerceUserAPI;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace ECommerceAPIGateway.Domain
{
    public class AuthService : IAuthService
    {
        private readonly RequestFactory _requestFactory;
        public AuthService(RequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        public async Task<string> SignIn(LoginModel loginModel)
        {
            return await _requestFactory.SendRequest("Authentication", "Login", loginModel, "POST");
        }
        public async Task<string> SignUp(RegisterModel registerModel)
        {
            return await _requestFactory.SendRequest("Authentication", "Login", registerModel, "POST");
        }
    }
}