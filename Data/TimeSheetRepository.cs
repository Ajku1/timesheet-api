using timesheet_api.Data.Entities.TimeOff;
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

    public IEnumerable<TimeOff> GetTimeOffsPendingReview(int managerId)
    {
        return _timesheetContext.TimeOff
            .Where(timeOff => timeOff.ManagerId.Equals(managerId) && timeOff.Status == TimeOffStatus.Pending)
            .ToList();
    }
}