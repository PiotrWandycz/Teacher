using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Teacher.Website.Feature.Category.CreateUpdate;
using System;
using Teacher.Website.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Teacher.Website.Feature.Tests.Infrastructure
{
    public class DependencyResolver
    {
        internal IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddScoped<IFacade, Facade>();
            services.AddScoped(x => new ConfigurationFactory().Create());
            services.AddDbContext<TeacherContext>(options =>
                options.UseSqlServer(new ConnectionStringFactory().Create()));
            return services.BuildServiceProvider();
        }
    }
}