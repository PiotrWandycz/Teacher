using Microsoft.Extensions.DependencyInjection;
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
