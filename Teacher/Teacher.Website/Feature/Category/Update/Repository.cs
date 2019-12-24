using Dapper;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Teacher.Website.Infrastructure;
using Teacher.Website.Infrastructure.Database;

namespace Teacher.Website.Feature.Category.Update
{
    class Repository : IRepository
    {
        private readonly IConnectionStringFactory _connectionStringFactory;
        private readonly TeacherContext _dbContext;

        public Repository(IConnectionStringFactory connectionStringFactory, TeacherContext dbContext)
        {
            _connectionStringFactory = connectionStringFactory;
            _dbContext = dbContext;
        }

        public async Task<ViewModel.CategoryViewModel> GetCategoryAsync(int categoryId)
        {
            using (var db = new SqlConnection(_connectionStringFactory.ToDatabase()))
            {
                var sql = $"SELECT [Id], [Name] FROM [Category] WHERE [Id] = { categoryId }";
                return await db.QueryFirstAsync<ViewModel.CategoryViewModel>(sql);
            }
        }

        public async Task UpdateCategoryAsync(int id, string name)
        {
            var category = await _dbContext.Category.FindAsync(id);
            if (category is null)
            {
                throw new NullReferenceException($"Category of id {id} not found");
            }
            category.Name = name;
            await _dbContext.SaveChangesAsync();
        }
    }
}