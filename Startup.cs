using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using timesheet_api.Data;
using timesheet_api.Data.Entities.User;

namespace timesheet_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            
            services.AddDbContext<TimesheetContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TimesheetDB"));
            });
            
            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                
            })
                .AddEntityFrameworkStores<TimesheetContext>();
            services.AddTransient<TimesheetSeeder>();
            services.AddScoped<ITimesheetRepository, TimeSheetRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}