namespace Application.Exceptions;

public class RegisterInvalidDataException : InvalidDataException
{
    public RegisterInvalidDataException(string? message)
        : base(message)
    {
    }
}
