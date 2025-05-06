namespace Application.Dtos.AuthDto;

public record IdentityUserResponseDto(
    string Username,
    string Email,
    string JwtToken
);
