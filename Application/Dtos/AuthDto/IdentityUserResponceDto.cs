namespace Application.Dtos.AuthDto;

public record IdentityUserResponceDto(
    string Username,
    string Email,
    string JwtToken
);
