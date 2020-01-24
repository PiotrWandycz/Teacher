using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System;
using Teacher.Website.Infrastructure;

namespace Teacher.Website.Feature.Tests.Infrastructure
{
    public class DependencyResolver
    {
        internal IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();
            services.Scan(x => x.FromAssemblyOf<Startup>()
                .AddClasses(x => x.AssignableTo<IPageFacadeMarker>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            services.Scan(x => x.FromAssemblyOf<Startup>()
                .AddClasses(x => x.AssignableTo<IRepositoryMarker>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            services.AddMediatR(typeof(Startup).Assembly);
            return services.BuildServiceProvider();
        }
    }
}