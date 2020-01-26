using MediatR.Pipeline;
using Serilog;
using System.Threading;
using System.Threading.Tasks;
using Teacher.Domain.Infrastructure;

namespace Teacher.Website.Feature.Interview.Answer
{
    public class ExceptionHandler : IRequestExceptionHandler<Query, ViewModel, DomainException>
    {
        public async Task Handle(Query request, DomainException ex, RequestExceptionHandlerState<ViewModel> state, CancellationToken cancellationToken)
        {
            Log.Error(ex, "Exception thrown at Feature/Interview/Answer");
            state.SetHandled(new ViewModel());
        }
    }
}