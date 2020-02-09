using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Serilog;
using System.Threading;
using System.Threading.Tasks;
using Teacher.Domain.Infrastructure;

namespace Teacher.Website.Feature.Interview.Answer
{
    public class DomainExceptionHandler : IRequestExceptionHandler<Query, ViewModel, DomainException>
    {
        public async Task Handle(Query request, DomainException exception, RequestExceptionHandlerState<ViewModel> state, CancellationToken cancellationToken)
        {
            Log.Error(exception, "Exception thrown at Query Feature/Interview/Answer");
            state.SetHandled(new ViewModel());
        }
    }

    public class ValidationExceptionHandler : IRequestExceptionHandler<Command, Unit, ValidationException>
    {
        public async Task Handle(Command request, ValidationException exception, RequestExceptionHandlerState<Unit> state, CancellationToken cancellationToken)
        {
            foreach (var error in exception.Errors)
            {
                Log.Error(exception, $"Exception thrown at Command Feature/Interview/Answer, because {error.ErrorMessage}");
            }
            state.SetHandled(Unit.Value);
        }
    }
}