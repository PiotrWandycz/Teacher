using MediatR;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Teacher.Website.Feature.Tests")]
namespace Teacher.Website.Feature.Category.Delete
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
            await _repository.DeleteCategoryAsync(command.Id);
            return Unit.Value;
        }
    }
}