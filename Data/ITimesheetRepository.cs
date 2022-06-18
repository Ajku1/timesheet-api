using timesheet_api.Data.Entities.TimeEntry;
using timesheet_api.Data.Entities.User;
using timesheet_api.Models;

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
    public TimeEntryType UpdateTimeEntryType(int id, TimeEntryTypeModel timeEntryTypeModel);
    public TimeEntryType GetTimeEntryType(int id);
}