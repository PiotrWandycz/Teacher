using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Teacher.Website.Feature.Tests")]
namespace Teacher.Website.Feature.Category.CreateUpdate
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
            if (!query.CategoryId.HasValue)
                return model;
            model.Category = await GetCategory(_configuration, query.CategoryId.Value);
            return model;
        }

        private async Task<Model.CategoryModel> GetCategory(IConfiguration configuration, int categoryId)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var sql = $"SELECT [Id], [Name] FROM [Category] WHERE [Id] = { categoryId }";
                return await db.QueryFirstAsync<Model.CategoryModel>(sql);
            }
        }
    }
}