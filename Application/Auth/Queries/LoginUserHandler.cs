namespace Application.Auth.Queries;

public class LoginUserHandler(
    UserManager<CustomIdentityUser> manager,
    IJwtSecurityService jwtSecurityService)
    : IQueryHandler<LoginUserQuery, LoginUserResult>
{
    public async Task<LoginUserResult> Handle(
        LoginUserQuery request,
        CancellationToken cancellationToken)
    {
        var user = await manager.FindByEmailAsync(request.dto.Email);

        if (user is null)
        {
            throw new UserNotFoundException(request.dto.Email);
        }

        var result = await manager.CheckPasswordAsync(user, request.dto.Password);

        if (result)
        {
            var response = new IdentityUserResponceDto(
                user.UserName!, user.Email!, jwtSecurityService.CreateToken(user)
            );

            return new LoginUserResult(response);
        }

        throw new UserNotFoundException(request.dto.Email);
    }
}
