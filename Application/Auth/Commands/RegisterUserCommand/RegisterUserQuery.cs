namespace Application.Auth.Commands.RegisterUserCommand;

public record RegisterUserQuery(RegisterUserRequestDto dto) : IQuery<RegisterUserResult>;

public record RegisterUserResult(IdentityUserResponseDto Identity);

