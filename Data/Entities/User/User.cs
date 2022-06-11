namespace timesheet_api.Data.Entities.User;

public class User
{
    public int Id { get; set; }
    public int ManagerId { get; set; }
    public String Name { get; set; }
    public String Email { get; set; }
    public UserRole Role { get; set; }
}