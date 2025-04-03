using Domain.Models;

namespace Domain.Interfaces;

public interface IJwtSecurityService
{
    string CreateToken(CustomIdentityUser user);
}
