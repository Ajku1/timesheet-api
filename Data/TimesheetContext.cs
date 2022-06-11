using Microsoft.EntityFrameworkCore;
using timesheet_api.Data.Entities.User;

namespace timesheet_api.Data;

public class TimesheetContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<User> TimeOff { get; set; }
}