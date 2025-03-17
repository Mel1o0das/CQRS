namespace Domain.Security.Dtos;

public record RegisterUserDto(
    string FullName,
    string Username,
    string Email,
    string Password
);