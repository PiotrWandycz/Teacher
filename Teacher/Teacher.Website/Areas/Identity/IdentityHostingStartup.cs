using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Teacher.Website.Areas.Identity.IdentityHostingStartup))]
namespace Teacher.Website.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}