namespace Application.Exceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string message)
        : base(message)
    {

    }

    public UserNotFoundException(string email, string username)
        : base($"User с email ({email}) или username ({username}) не найден")
    {

    }
}
