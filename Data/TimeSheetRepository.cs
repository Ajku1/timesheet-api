using timesheet_api.Data.Entities.TimeEntry;
using timesheet_api.Data.Entities.User;

namespace timesheet_api.Data;

public class TimeSheetRepository : ITimesheetRepository
{
    private readonly TimesheetContext _timesheetContext;

    public TimeSheetRepository(TimesheetContext timesheetContext)
    {
        _timesheetContext = timesheetContext;
    }

    public object Save(object obj)
    {
        var savedEntity = _timesheetContext.Add(obj);
        _timesheetContext.SaveChanges();
        return savedEntity.Entity;
    }

    public IEnumerable<User> GetUsers()
    {
        return _timesheetContext.Users
            .ToList();
    }

    public IEnumerable<TimeEntry> GetTimeEntriesPendingReview(int managerId)
    {
        return _timesheetContext.TimeEntries
            .Where(timeEntry => timeEntry.ManagerId.Equals(managerId) && timeEntry.Status == TimeEntryStatus.Pending)
            .ToList();
    }

    public TimeEntry ActOnTimeEntry(int timeEntryId, bool approved)
    {
        TimeEntry timeEntry = _timesheetContext.TimeEntries
            .Single(timeEntry => timeEntry.Id.Equals(timeEntryId));
        timeEntry.Status = approved ? TimeEntryStatus.Approved : TimeEntryStatus.Denied;
        return _timesheetContext.TimeEntries.Update(timeEntry).Entity;
    }

    public bool isEmailInUse(string email)
    {
        return _timesheetContext.Users.Any(user => user.Email.Equals(email));
    }
}