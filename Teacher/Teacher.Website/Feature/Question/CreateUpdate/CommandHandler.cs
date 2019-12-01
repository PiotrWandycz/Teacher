using MediatR;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Teacher.Website.Enums;
using Teacher.Website.Infrastructure.Database;

[assembly: InternalsVisibleTo("Teacher.Website.Feature.Tests")]
namespace Teacher.Website.Feature.Question.CreateUpdate
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
            if (!string.IsNullOrWhiteSpace(command.Question.AnswerJunior))
                command.Question.Level = QuestionLevel.Junior;
            if (!string.IsNullOrWhiteSpace(command.Question.AnswerRegular))
                command.Question.Level = QuestionLevel.Junior | QuestionLevel.Regular;
            if (!string.IsNullOrWhiteSpace(command.Question.AnswerSenior))
                command.Question.Level = QuestionLevel.Junior | QuestionLevel.Regular | QuestionLevel.Senior;

            var question = await _dbContext.Question.FindAsync(command.Question.QuestionId);
            if (question is null)
            {
                question = new Infrastructure.Database.Question();
                await _dbContext.Question.AddAsync(question, cancellationToken);
            }
            question.Content = command.Question.Content;
            question.CategoryId = command.Question.CategoryId;
            question.Level = (byte)command.Question.Level;
            question.AnswerJunior = command.Question.AnswerJunior;
            question.AnswerRegular = command.Question.AnswerRegular;
            question.AnswerSenior = command.Question.AnswerSenior;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}