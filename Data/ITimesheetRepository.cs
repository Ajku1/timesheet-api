using timesheet_api.Data.Entities.TimeOff;
using timesheet_api.Data.Entities.User;

namespace timesheet_api.Data;

public interface ITimesheetRepository
{
    public bool Save(object obj);
    public IEnumerable<User> GetUsers();
    public IEnumerable<TimeOff> GetTimeOffsPendingReview(int managerId);
}