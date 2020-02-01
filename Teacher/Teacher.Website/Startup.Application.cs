using Microsoft.Extensions.DependencyInjection;
using Teacher.Website.Infrastructure;
using Teacher.Domain.Infrastructure;

namespace Teacher.Website
{
    public partial class Startup
    {
        private void ConfigureApplication(IServiceCollection services)
        {
            services.Scan(x => x.FromAssemblyOf<Startup>()
                .AddClasses(x => x.AssignableTo<IPageFacadeMarker>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            services.Scan(x => x.FromAssemblyOf<Startup>()
                .AddClasses(x => x.AssignableTo<IRepositoryMarker>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            services.RegisterDomain();
        }
    }
}