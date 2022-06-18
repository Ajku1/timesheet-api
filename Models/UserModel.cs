using timesheet_api.Data.Entities.User;

namespace timesheet_api.Models;

public class UserModel
{
    public string Id { get; set; }
    public string ManagerId { get; set; }
    public string Name { get; set; }
    public UserRole Role { get; set; }
}