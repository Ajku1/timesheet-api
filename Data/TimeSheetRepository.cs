using Microsoft.EntityFrameworkCore;
using timesheet_api.Data.Entities.TimeEntry;
using timesheet_api.Data.Entities.User;
using timesheet_api.Models;

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

    public IEnumerable<TimeEntry> GetUserTimeEntries(string userId)
    {
        return _timesheetContext.TimeEntries
            .Where(timeEntry => timeEntry.UserId.Equals(userId))
            .Include(timeEntry => timeEntry.User)
            .Include(timeEntry => timeEntry.Manager)
            .Include(timeEntry => timeEntry.Type)
            .ToList();
    }

    public IEnumerable<TimeEntry> GetTimeEntriesPendingReview(string managerId)
    {
        return _timesheetContext.TimeEntries
            .Where(timeEntry => timeEntry.ManagerId.Equals(managerId) && timeEntry.Status == TimeEntryStatus.Pending)
            .Include(timeEntry => timeEntry.User)
            .Include(timeEntry => timeEntry.Manager)
            .Include(timeEntry => timeEntry.Type)
            .ToList();
    }

    public TimeEntry ActOnTimeEntry(int timeEntryId, bool approved)
    {
        TimeEntry timeEntry = _timesheetContext.TimeEntries
            .Include(timeEntry => timeEntry.User)
            .Include(timeEntry => timeEntry.Manager)
            .Include(timeEntry => timeEntry.Type)
            .Single(timeEntry => timeEntry.Id.Equals(timeEntryId));
        timeEntry.Status = approved ? TimeEntryStatus.Approved : TimeEntryStatus.Denied;
        var entityEntry = _timesheetContext.TimeEntries.Update(timeEntry);
        _timesheetContext.SaveChanges();
        return entityEntry.Entity;
    }

    public bool isEmailInUse(string email)
    {
        return _timesheetContext.Users.Any(user => user.Email.Equals(email));
    }

    public User getUser(string username)
    {
        return _timesheetContext.Users.Single(user => user.UserName.Equals(username));
    }

    public IEnumerable<TimeEntryType> GetTimeEntryTypes()
    {
        return _timesheetContext.TimeEntryTypes.ToList();
    }

    public TimeEntryType UpdateTimeEntryType(int id, TimeEntryTypeModel timeEntryTypeModel)
    {
        TimeEntryType timeEntryType = _timesheetContext.TimeEntryTypes
            .Single(timeEntryType => timeEntryType.Id == id);
        timeEntryType.Name = timeEntryTypeModel.Name;

        var entityEntry = _timesheetContext.TimeEntryTypes.Update(timeEntryType);
        _timesheetContext.SaveChanges();
        return entityEntry.Entity;
    }

    public TimeEntryType GetTimeEntryType(int id)
    {
        return _timesheetContext.TimeEntryTypes.Single(timeEntryType => timeEntryType.Id == id);
    }
}