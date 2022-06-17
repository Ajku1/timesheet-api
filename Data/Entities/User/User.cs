using Microsoft.AspNetCore.Identity;

namespace timesheet_api.Data.Entities.User;

public class User : IdentityUser
{
    public string? ManagerId { get; set; }
    public string Name { get; set; }
    public UserRole Role { get; set; }
}