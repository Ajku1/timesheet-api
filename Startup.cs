using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using timesheet_api.Data;
using timesheet_api.Data.Entities.User;

namespace timesheet_api
{
    public class Startup
    {
        private readonly string _corsPolicyName = "CorsPolicy";
        private readonly string _frontendOrigin = "https://localhost:4200";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(_corsPolicyName,
                    policy =>
                    {
                        policy.WithOrigins(_frontendOrigin)
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });

            services.AddDbContext<TimesheetContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TimesheetDB"));
            });

            services.AddIdentity<User, IdentityRole>(config => { config.User.RequireUniqueEmail = true; })
                .AddEntityFrameworkStores<TimesheetContext>();
            services.AddTransient<TimesheetSeeder>();
            services.AddScoped<ITimesheetRepository, TimeSheetRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(_corsPolicyName);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}