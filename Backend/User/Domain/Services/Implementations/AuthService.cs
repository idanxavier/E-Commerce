using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

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

    public async Task<UserDTO> SignIn(LoginModel loginModel) {
        IdentityUser user = await _userManager.FindByNameAsync(loginModel.Username);
        if (user == null)
            throw new ArgumentException("User doesn't exists.");

        if(!await _userManager.CheckPasswordAsync(user, loginModel.Password))
            throw new ArgumentException("Wrong password.");

        var roles = await _userManager.GetRolesAsync(user);
        var authClaims = new List<Claim> {
             new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        foreach (var userRole in roles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        var token = GetToken(authClaims);
        UserDTO userDTO = new UserDTO() {
            User = user,
            Token = new JWTToken() {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            }
        };
        return userDTO;

    }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
}