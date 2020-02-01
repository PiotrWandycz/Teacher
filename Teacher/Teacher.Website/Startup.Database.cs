using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teacher.Website.Infrastructure.Database;
using Teacher.Website.Infrastructure;

namespace Teacher.Website
{
    public partial class Startup
    {
        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddSingleton<IConnectionStringFactory, ConnectionStringFactory>();
            services.AddDbContext<TeacherContext>(options =>
                            options.UseSqlServer(
                                Configuration.GetConnectionString("DatabaseConnection")));
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DatabaseConnection")));
        }
    }
}