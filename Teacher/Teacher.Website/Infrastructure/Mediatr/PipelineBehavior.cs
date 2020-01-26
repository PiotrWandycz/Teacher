using MediatR;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace Teacher.Website.Infrastructure.Mediatr
{
    public class PipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Log.Debug($"-- Handling request: {request.GetType()} | Awaiting response: {next.GetType()}");
            var response = await next();
            Log.Debug($"-- Finished request: {request.GetType()}");
            return response;
        }
    }
}