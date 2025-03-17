namespace Domain.Security.Dtos;

public record IdentityUserResponceDto(
    string Username,
    string Email,
    string JwtToken
);
