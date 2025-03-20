namespace Application.Dtos.AuthDto;

public record RegisterUserRequestDto(
    string FullName,
    string Username,
    string Email,
    string Password
);