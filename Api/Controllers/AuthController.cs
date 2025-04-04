using Application.Dtos.AuthDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
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
    public async Task<IResult> Login(LoginRequest dto)
    {
        var response = await mediator.Send(new LoginUserQuery(dto));
        return Results.Ok(new { result = response.Identity });
    }

    [HttpPost("register")]
    public async Task<IResult> Register(RegisterUserRequestDto dto)
    {
        try
        {
            var response = await mediator.Send(new RegisterUserQuery(dto));
            return Results.Ok(new { result = response.Identity });
        }
        catch (RegisterInvalidDataException ex)
        {
            return Results.BadRequest(ex.Message);
        }

        //return Results.BadRequest(result.Errors);
    }
}