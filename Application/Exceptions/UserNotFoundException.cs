namespace Application.Exceptions;

public class UserNotFoundException : NotFoundException
{
    // public UserNotFoundException(string message)
    //     : base(message)
    // {

    // }

    public UserNotFoundException(string email)
        : base($"User с email ({email}) не найден")
    {

    }
}
