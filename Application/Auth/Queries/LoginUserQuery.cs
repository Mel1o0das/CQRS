namespace Application.Auth.Queries;

public record LoginUserQuery(LoginRequestDto dto) : IQuery<LoginUserResult>;

public record LoginUserResult(IdentityUserResponseDto Identity);