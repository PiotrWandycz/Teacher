using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Teacher.Website.Infrastructure.Database;
using Teacher.Website.Infrastructure;

namespace Teacher.Website
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
            ConfigureRazorPages(services);
            ConfigureDatabase(services);
            ConfigureApp(services);
        }

        private void ConfigureRazorPages(IServiceCollection services)
        {
            services.AddRazorPages()
                .AddRazorPagesOptions(options => { options.RootDirectory = "/Feature"; });
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<IdentityContext>();
        }

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

        private void ConfigureApp(IServiceCollection services)
        {
            services.Scan(x => x.FromAssemblyOf<Startup>()
                .AddClasses(x => x.AssignableTo<IPageFacadeMarker>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            services.Scan(x => x.FromAssemblyOf<Startup>()
                .AddClasses(x => x.AssignableTo<IRepositoryMarker>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            services.AddMediatR(typeof(Startup).Assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}