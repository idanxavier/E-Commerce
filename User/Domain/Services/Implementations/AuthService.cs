using Microsoft.AspNetCore.Identity;

namespace ECommerceUserAPI;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration) {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    public async Task<IdentityUser> SignUp(RegisterModel registerModel) {
        var userExists = await _userManager.FindByNameAsync(registerModel.Username);
        if (userExists != null)
            throw new ArgumentException("Username already exists.");

        IdentityUser user = new()
        {
            Email = registerModel.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = registerModel.Username
        };

        var result = await _userManager.CreateAsync(user, registerModel.Password);
        if (!result.Succeeded)
            throw new ArgumentException("User creation failed! Please check user details and try again.");

        return user;
    }
}