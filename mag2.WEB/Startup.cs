using mag2.DAL.Interfaces;
using mag2.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using mag2.BLL.Interfaces;
using mag2.BLL.Services;
using mag2.DAL.EF;


public class Startup
{
    public Startup(IConfigurationRoot configuration)
    {
        Configuration = configuration;
    }
    public IConfigurationRoot Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        services.AddTransient<IUnitOfWork, EFUnitOfWork>();
        services.AddTransient<ITaskService, TaskService>();

        string connection = Configuration.GetConnectionString("DefaultConnection")!;
        services.AddDbContext<TaskContext>(options => options.UseNpgsql(connection));

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseEndpoints(x => x.MapControllers());
    }
}