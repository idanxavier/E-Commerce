using ECommerceUserAPI;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPIGateway.Domain.Service.Interfaces
{
    public interface IAuthService
    {
        Task<string> SignIn(LoginModel loginModel);
        Task<string> SignUp(RegisterModel registerModel);
    }
}