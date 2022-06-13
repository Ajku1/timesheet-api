using Microsoft.AspNetCore.Identity;

namespace timesheet_api.Data.Entities.User;

public class User : IdentityUser
{
    public int? ManagerId { get; set; }
    public String Name { get; set; }
    public UserRole Role { get; set; }
}