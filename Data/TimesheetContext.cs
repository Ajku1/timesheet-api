using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using timesheet_api.Data.Entities.TimeEntry;
using timesheet_api.Data.Entities.User;

namespace timesheet_api.Data;

public class TimesheetContext : IdentityDbContext<User>
{
    public TimesheetContext(DbContextOptions<TimesheetContext> options) : base(options)
    {
    }

    public DbSet<TimeEntry> TimeEntries { get; set; }
    public DbSet<TimeEntryType> TimeEntryTypes { get; set; }
}