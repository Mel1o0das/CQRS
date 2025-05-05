namespace Application.Auth.Commands.RegisterUserCommand;

public record RegisterUserCommand(RegisterUserRequestDto dto) : ICommand<RegisterUserResult>;

public record RegisterUserResult(IdentityUserResponseDto Identity);

