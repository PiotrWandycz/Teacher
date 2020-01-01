using MediatR;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Teacher.Website.Feature.Tests")]
namespace Teacher.Website.Feature.Question.CreateUpdate
{
    internal class CommandHandler : IRequestHandler<Command>
    {
        private readonly IRepository _repository;

        public CommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
        {
            if (command.Question.Id > 0)
                await _repository.UpdateQuestionAsync(command.Question);
            else
                await _repository.CreateQuestionAsync(command.Question);
            return Unit.Value;
        }
    }
}