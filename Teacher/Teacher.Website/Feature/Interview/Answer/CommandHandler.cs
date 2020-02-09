using FluentValidation;
using MediatR;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Teacher.Website.Feature.Tests")]
namespace Teacher.Website.Feature.Interview.Answer
{
    internal class CommandHandler : IRequestHandler<Command>
    {
        private readonly IRepository _repository;
        private readonly CommandValidator _validator;

        public CommandHandler(IRepository repository)
        {
            _repository = repository;
            _validator = new CommandValidator();
        }

        public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
        {
            ValidateCommand(command);
            await _repository.CreateAnswerAsync(command);
            return Unit.Value;
        }

        private void ValidateCommand(Command command)
        {
            var validationResult = _validator.Validate(command);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
        }
    }
}