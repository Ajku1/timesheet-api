using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using timesheet_api.Data.Entities;
using timesheet_api.Data.Entities.TimeEntry;
using timesheet_api.Data.Entities.User;

namespace timesheet_api.Data;

public class TimesheetContext : IdentityDbContext<User>
{
    public TimesheetContext(DbContextOptions<TimesheetContext> options) : base(options)
    {
    }

    // public DbSet<User> Users { get; set; }
    public DbSet<TimeEntry> TimeEntries { get; set; }
    
}