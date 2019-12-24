using System.Threading.Tasks;
using Teacher.Website.Infrastructure.Database;

namespace Teacher.Website.Feature.Category.Create
{
    class Repository : IRepository
    {
        private readonly TeacherContext _dbContext;

        public Repository(TeacherContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateCategoryAsync(string name)
        {
            var category = new Infrastructure.Database.Category
            {
                Name = name, 
                ItemOrder = byte.MaxValue 
            };
            await _dbContext.Category.AddAsync(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}