using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Teacher.Website.Infrastructure;
using Microsoft.AspNetCore.Http;
using FluentValidation.AspNetCore;

namespace Teacher.Website
{
    public partial class Startup
    {
        private void ConfigureRazorPages(IServiceCollection services)
        {
            services.AddRazorPages()
                .AddFluentValidation()
                .AddRazorPagesOptions(options => { options.RootDirectory = "/Feature"; });
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<IdentityContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
        }
    }
}