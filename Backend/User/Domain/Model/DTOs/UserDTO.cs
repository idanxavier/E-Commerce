using Microsoft.AspNetCore.Identity;

public class UserDTO {

    public IdentityUser User { get; set; }
    public JWTToken Token { get; set; }

}