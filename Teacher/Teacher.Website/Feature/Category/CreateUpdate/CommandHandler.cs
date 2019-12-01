using MediatR;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Teacher.Website.Infrastructure.Database;

[assembly: InternalsVisibleTo("Teacher.Website.Feature.Tests")]
namespace Teacher.Website.Feature.Category.CreateUpdate
{
    internal class CommandHandler : IRequestHandler<Command, Unit>
    {
        private readonly TeacherContext _dbContext;

        public CommandHandler(TeacherContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Category.FindAsync(command.Category.Id);
            if (category is null)
            {
                category = new Infrastructure.Database.Category() { Name = string.Empty, ItemOrder = byte.MaxValue };
                await _dbContext.Category.AddAsync(category, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            category.Name = command.Category.Name;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}