using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Teacher.Website.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace Teacher.Website
{
    public partial class Startup
    {
        private void ConfigureRazorPages(IServiceCollection services)
        {
            services.AddRazorPages()
                .AddRazorPagesOptions(options => { options.RootDirectory = "/Feature"; });
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<IdentityContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
        }
    }
}