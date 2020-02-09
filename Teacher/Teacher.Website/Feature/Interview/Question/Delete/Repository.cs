using System.Threading.Tasks;
using Teacher.Website.Infrastructure;
using Teacher.Website.Infrastructure.Database;

namespace Teacher.Website.Feature.Interview.Question.Delete
{
    class Repository : IRepository
    {
        private readonly TeacherContext _dbContext;

        public Repository(IConnectionStringFactory connectionStringFactory, TeacherContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteQuestionAsync(int id)
        {
            var question = await _dbContext.Question.FindAsync(id);
            if (question is null)
            {
                return;
            }
            _dbContext.Question.Remove(question);
            await _dbContext.SaveChangesAsync();
        }
    }
}