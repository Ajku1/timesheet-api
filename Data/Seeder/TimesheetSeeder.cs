using System.Text.Json;
using timesheet_api.Data.Entities.User;

namespace timesheet_api.Data;

public class TimesheetSeeder
{
    private readonly TimesheetContext _timesheetContext;
    private readonly IWebHostEnvironment _environment;

    public TimesheetSeeder(TimesheetContext timesheetContext, IWebHostEnvironment environment)
    {
        _timesheetContext = timesheetContext;
        _environment = environment;
    }

    public void Seed()
    {
        _timesheetContext.Database.EnsureCreated();

        if (!_timesheetContext.Users.Any())
        {
            var filePath = Path.Combine(_environment.ContentRootPath, "Data/Seeder/seeds/users.json");
            var json = File.ReadAllText(filePath);
            var users = JsonSerializer.Deserialize<IEnumerable<User>>(json);

            _timesheetContext.Users.AddRange(users);
            _timesheetContext.SaveChanges();
        }
    }
}