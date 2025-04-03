using Microsoft.AspNetCore.Identity;

namespace Domain.Models;

public class CustomIdentityUser : IdentityUser
{
    public string FullName { get; set; } = default!;
    public string About { get; set; } = default!;
}
