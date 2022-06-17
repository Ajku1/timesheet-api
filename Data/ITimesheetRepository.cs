using timesheet_api.Data.Entities.TimeEntry;
using timesheet_api.Data.Entities.User;

namespace timesheet_api.Data;

public interface ITimesheetRepository
{
    public object Save(object obj);
    public IEnumerable<User> GetUsers();
    public IEnumerable<TimeEntry> GetTimeEntriesPendingReview(int managerId);
    public TimeEntry ActOnTimeEntry(int timeEntryId, bool approved);
    public bool isEmailInUse(string email);
}