using Microsoft.EntityFrameworkCore;
using timesheet_api.Data.Entities.TimeOff;
using timesheet_api.Data.Entities.User;

namespace timesheet_api.Data;

public class TimesheetContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<TimeOff> TimeOff { get; set; }
    
    public TimesheetContext(DbContextOptions<TimesheetContext> options) : base(options)
    {
    }
}