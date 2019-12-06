using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Teacher.Website.Infrastructure.Database;

namespace Teacher.Website.Feature.Category.CreateUpdate
{
    class Repository : IRepository
    {
        private readonly IConfiguration _configuration;
        private readonly TeacherContext _dbContext;

        public Repository(IConfiguration configuration, TeacherContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public async Task<Model.CategoryModel> GetCategoryAsync(int categoryId)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var sql = $"SELECT [Id], [Name] FROM [Category] WHERE [Id] = { categoryId }";
                return await db.QueryFirstAsync<Model.CategoryModel>(sql);
            }
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

        public async Task UpdateCategoryAsync(int id, string name)
        {
            var category = await _dbContext.Category.FindAsync(id);
            if (category is null)
            {
                category = new Infrastructure.Database.Category { ItemOrder = byte.MaxValue };
                await _dbContext.Category.AddAsync(category);
                await _dbContext.SaveChangesAsync();
            }
            category.Name = name;
            await _dbContext.SaveChangesAsync();
        }
    }
}
