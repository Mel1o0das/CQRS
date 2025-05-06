namespace Application.Dtos.AuthDto;

public record LoginRequestDto(
    string Email,
    string Password
);