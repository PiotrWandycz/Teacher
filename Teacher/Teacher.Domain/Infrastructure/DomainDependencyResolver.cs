using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Text;
using Teacher.Domain.SelectQuestions;

namespace Teacher.Domain.Infrastructure
{
    public static class DomainDependencyResolver
    {
        public static void RegisterDomain(this IServiceCollection services)
        {
            services.Scan(x => x.FromAssemblyOf<QuestionSelector>()
                .AddClasses(y => y.AssignableTo<IDomainService>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
    }
}
