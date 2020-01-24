using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Teacher.Website.Infrastructure;

namespace Teacher.Website.Feature.Category.List
{
    class Repository : IRepository
    {
        private readonly IConnectionStringFactory _connectionStringFactory;

        public Repository(IConnectionStringFactory connectionStringFactory)
        {
            _connectionStringFactory = connectionStringFactory;
        }

        public async Task<IEnumerable<ViewModel.CategoryViewModel>> GetCategoriesAsync()
        {
            using (var db = new SqlConnection(_connectionStringFactory.ToDatabase()))
            {
                var sql = "SELECT [Id], [Name] FROM [Category]";
                return await db.QueryAsync<ViewModel.CategoryViewModel>(sql);
            }
        }
    }
}