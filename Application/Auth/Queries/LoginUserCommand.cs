namespace Application.Auth.Queries;

public record LoginUserCommand(LoginRequestDto dto) : ICommand<LoginUserResult>;

public record LoginUserResult(IdentityUserResponseDto Identity);