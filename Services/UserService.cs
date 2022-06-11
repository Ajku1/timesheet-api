using timesheet_api.Data.Entities.User;

namespace timesheet_api.Services;

public class UserService
{
    public List<User> GetAll()
    {
        List<User> users = new List<User>();
        User testUser = new User();
        users.Add(testUser);
        return users;
    }
}