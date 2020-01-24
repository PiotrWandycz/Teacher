using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System;
using Teacher.Website.Infrastructure;
using Teacher.Website.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Teacher.Website.Integration.Tests.Infrastructure
{
    public class DependencyResolver
    {
        internal IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddSingleton(x => new ConfigurationFactory().Create());
            services.AddSingleton<IConnectionStringFactory, ConnectionStringFactory>();
            services.AddDbContext<TeacherContext>(options =>
                options.UseSqlServer(new ConnectionStringFactory().ToDatabase()));
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