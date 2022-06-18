using timesheet_api.Data.Entities.TimeEntry;
using timesheet_api.Data.Entities.User;

namespace timesheet_api.Data;

public interface ITimesheetRepository
{
    public object Save(object obj);
    public IEnumerable<User> GetUsers();
    public IEnumerable<TimeEntry> GetUserTimeEntries(string userId);
    public IEnumerable<TimeEntry> GetTimeEntriesPendingReview(string managerId);
    public TimeEntry ActOnTimeEntry(int timeEntryId, bool approved);
    public bool isEmailInUse(string email);

    public User getUser(string id);
    public IEnumerable<TimeEntryType> GetTimeEntryTypes();
}