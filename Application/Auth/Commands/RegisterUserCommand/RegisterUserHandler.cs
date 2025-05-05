using Domain.Interfaces;

namespace Application.Auth.Commands.RegisterUserCommand;

public class RegisterUserHandler(
    UserManager<CustomIdentityUser> manager,
    IJwtSecurityService jwtSecurityService)
    : IQueryHandler<RegisterUserQuery, RegisterUserResult>
{
    public async Task<RegisterUserResult> Handle(
        RegisterUserQuery request,
        CancellationToken cancellationToken)
    {
        if (await manager.Users.AnyAsync(u => u.UserName == request.dto.Username))
        {
            throw new RegisterInvalidDataException("Username занят");
        }

        if (await manager.Users.AnyAsync(u => u.Email == request.dto.Email))
        {
            throw new RegisterInvalidDataException("Email занят");
        }

        var user = new CustomIdentityUser
        {
            FullName = request.dto.FullName,
            Email = request.dto.Email,
            UserName = request.dto.Username,
            About = String.Empty
        };

        var result = await manager.CreateAsync(user, request.dto.Password!);

        if (result.Succeeded)
        {
            var response = new IdentityUserResponseDto(
                user.UserName!, user.Email!, jwtSecurityService.CreateToken(user)
            );

            return new RegisterUserResult(response);
        }

        throw new RegisterInvalidDataException($"{result.Errors}");
    }
}
