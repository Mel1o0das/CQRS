using API.Security.Services;
using Domain.Security;
using Domain.Security.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(UserManager<CustomIdentityUser> manager, IJwtSecurityService jwtSecurityService)
    : ControllerBase
{
    [HttpPost("login")]
    public async Task<IResult> Login(LoginRequest dto)
    {
        var user = await manager.FindByEmailAsync(dto.Email);

        if (user is null)
        {
            return Results.Unauthorized();
        }

        var result = await manager.CheckPasswordAsync(user, dto.Password);

        if (result)
        {
            var response = new IdentityUserResponceDto(
                user.UserName!, user.Email!, jwtSecurityService.CreateToken(user)
            );

            return Results.Ok(new { result = response });
        }

        return Results.Unauthorized();
    }
}