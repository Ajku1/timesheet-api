// using Microsoft.EntityFrameworkCore;
// using timesheet_api.Data;
// using timesheet_api.Services;
//
// namespace timesheet_api
// {
//     public class Startup
//     {
//         public Startup(IConfiguration configuration)
//         {
//             Configuration = configuration;
//         }
//
//         public IConfiguration Configuration { get; }
//
//         // This method gets called by the runtime. Use this method to add services to the container.
//         public void ConfigureServices(IServiceCollection services)
//         {
//             services.AddControllers();
//             services.AddScoped<UserService>();
//             services.AddCors();
//             services.AddDbContext<TimesheetContext>(options =>
//             {
//                 options.UseSqlServer(Configuration.GetConnectionString("TimeSheetDB"));
//             });
//         }
//
//         // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//         public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//         {
//             app.UseDeveloperExceptionPage();
//             app.UseHttpLogging();
//             app.UseRouting();
//             app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
//             app.UseAuthorization();
//
//             app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
//         }
//     }
// }