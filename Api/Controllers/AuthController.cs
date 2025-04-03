using Application.Dtos.AuthDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Application.Auth.Queries;
using Domain.Interfaces;

namespace Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class AuthController(
    IMediator mediator,
    UserManager<CustomIdentityUser> manager,
    IJwtSecurityService jwtSecurityService)
    : ControllerBase
{
    [HttpPost("login")]
    public async Task<IResult> Login(LoginRequest dto)
    {
        var response = await mediator.Send(new LoginUserQuery(dto));
        return Results.Ok(new { result = response.Identity });
    }

    [HttpPost("register")]
    public async Task<IResult> Register(RegisterUserRequestDto dto)
    {
        if (await manager.Users.AnyAsync(u => u.UserName == dto.Username))
        {
            return Results.BadRequest("Username занят");
        }

        if (await manager.Users.AnyAsync(u => u.Email == dto.Email))
        {
            return Results.BadRequest("Email занят");
        }

        var user = new CustomIdentityUser
        {
            FullName = dto.FullName,
            Email = dto.Email,
            UserName = dto.Username,
            About = String.Empty
        };

        var result = await manager.CreateAsync(user, dto.Password!);

        if (result.Succeeded)
        {
            var response = new IdentityUserResponceDto(
                user.UserName!, user.Email!, jwtSecurityService.CreateToken(user)
            );

            return Results.Ok(new { result = response });
        }

        return Results.BadRequest(result.Errors);
    }
}