using Application.Dtos.AuthDto;
using Microsoft.AspNetCore.Authorization;
using Application.Auth.Queries;
using Application.Auth.Commands.RegisterUserCommand;

namespace Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class AuthController(
    IMediator mediator)
    : ControllerBase
{
    [HttpPost("login")]
    public async Task<IResult> Login(LoginRequestDto dto)
    {
        var response = await mediator.Send(new LoginUserCommand(dto));
        return Results.Ok(new { result = response.Identity });
    }

    [HttpPost("register")]
    public async Task<IResult> Register(RegisterUserRequestDto dto)
    {
        var response = await mediator.Send(new RegisterUserCommand(dto));
        return Results.Ok(new { result = response.Identity });
    }
}