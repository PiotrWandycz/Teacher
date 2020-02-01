using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Teacher.Website.Infrastructure.Mediatr;

namespace Teacher.Website
{
    public partial class Startup
    {
        private void ConfigureMediatR(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PipelineBehavior<,>));
        }
    }
}