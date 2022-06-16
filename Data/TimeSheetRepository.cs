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

    public bool Save(object obj)
    {
        _timesheetContext.Add(obj);
        return _timesheetContext.SaveChanges() > 0;
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
}