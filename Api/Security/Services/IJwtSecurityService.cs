using Domain.Security;

namespace API.Security.Services;

public interface IJwtSecurityService
{
    string CreateToken(CustomIdentityUser user);
}
