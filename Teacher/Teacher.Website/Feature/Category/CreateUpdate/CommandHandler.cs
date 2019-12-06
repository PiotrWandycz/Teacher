using MediatR;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Teacher.Website.Feature.Tests")]
namespace Teacher.Website.Feature.Category.CreateUpdate
{
    internal class CommandHandler : IRequestHandler<Command, Unit>
    {
        private readonly IRepository _repository;

        public CommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
        {
            if (command.Category.Id > 0)
                await _repository.UpdateCategoryAsync(command.Category.Id, command.Category.Name);
            else
                await _repository.CreateCategoryAsync(command.Category.Name);
            return Unit.Value;
        }
    }
}