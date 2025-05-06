using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Infrastructure.Security.Services;

public class JwtSecurityService(IConfiguration configuration) : IJwtSecurityService
{
    public string CreateToken(CustomIdentityUser user)
    {
        string secretKey = configuration["AuthSettings:SecretKey"]!;

        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Name, user.UserName!),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim("is_premium", "true"),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var tokenHandler = new JsonWebTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = creds,
            Subject = new ClaimsIdentity(claims),
            IssuedAt = DateTime.UtcNow,
            NotBefore = DateTime.UtcNow.AddMinutes(0),
            Expires = DateTime.UtcNow.AddMinutes(1)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return token;
    }
}
