using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System;
using Teacher.Website.Infrastructure;

namespace Teacher.Website.Integration.Tests.Infrastructure
{
    public class DependencyResolver
    {
        internal IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddMediatR(typeof(Startup).Assembly);
            services.Scan(x => x.FromAssemblyOf<Startup>()
                .AddClasses(x => x.AssignableTo<IPageFacadeMarker>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            services.Scan(x => x.FromAssemblyOf<Startup>()
                .AddClasses(x => x.AssignableTo<IRepositoryMarker>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services.BuildServiceProvider();
        }
    }
}