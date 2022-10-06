using Microsoft.AspNetCore.Identity;

namespace ECommerceUserAPI;

public interface IAuthService
{
    Task<IdentityUser> SignUp(RegisterModel registerModel);
}