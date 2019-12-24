using System.Threading.Tasks;
using Teacher.Website.Infrastructure;
using Teacher.Website.Infrastructure.Database;

namespace Teacher.Website.Feature.Category.Delete
{
    class Repository : IRepository
    {
        private readonly TeacherContext _dbContext;

        public Repository(IConnectionStringFactory connectionStringFactory, TeacherContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _dbContext.Category.FindAsync(id);
            if (category is null)
            {
                return;
            }
            _dbContext.Category.Remove(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}