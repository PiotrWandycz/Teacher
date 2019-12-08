using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Teacher.Website.Feature.Tests")]
namespace Teacher.Website.Feature.Category.List
{
    internal class QueryHandler : IRequestHandler<Query, Model>
    {
        private readonly IConfiguration _configuration;

        public QueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Model> Handle(Query query, CancellationToken cancellationToken)
        {
            var model = new Model();
            model.Categories = await GetCategories(_configuration);
            return model;
        }

        private async Task<IEnumerable<Model.CategoryModel>> GetCategories(IConfiguration configuration)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
            {
                var sql = "SELECT [Id], [Name] FROM [Category]";
                return await db.QueryAsync<Model.CategoryModel>(sql);
            }
        }
    }
}