using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using timesheet_api.Data.Entities.User;

namespace timesheet_api.Data;

public class TimesheetSeeder
{
    private readonly TimesheetContext _timesheetContext;
    private readonly IWebHostEnvironment _environment;
    private readonly UserManager<User> _userManager;

    public TimesheetSeeder(
        TimesheetContext timesheetContext, 
        IWebHostEnvironment environment,
        UserManager<User> userManager)
    {
        _timesheetContext = timesheetContext;
        _environment = environment;
        _userManager = userManager;
    }

    public async Task SeedAsync()
    {
        await _timesheetContext.Database.EnsureCreatedAsync();

        User user = await _userManager.FindByEmailAsync("niki@abv.bg");
        if (user == null)
        {
            user = new User()
            {
                Name = "NikolaK",
                Email = "niki@abv.bg",
                Role = UserRole.Administrator,
                UserName = "Ajki"
            };
            
            var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
            if (result != IdentityResult.Success)
            {
                throw new InvalidOperationException("Failed to create admin user in seeder.");
            }
        }

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