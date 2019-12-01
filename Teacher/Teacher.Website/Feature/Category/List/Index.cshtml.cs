using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Teacher.Website.Feature.Category.List
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
            => _mediator = mediator;

        public Model Data { get; private set; }

        public async Task OnGetAsync(Query query)
            => Data = await _mediator.Send(query);

        public class Query : IRequest<Model>
        {

        }

        public class Model
        {
            public IEnumerable<CategoryModel> Categories { get; set; }

            public class CategoryModel
            {
                public int Id { get; set; }
                public string Name { get; set; }
            }
        }

        private class QueryHandler : IRequestHandler<Query, Model>
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
                using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var sql = "SELECT [Id], [Name] FROM [Category]";
                    return await db.QueryAsync<Model.CategoryModel>(sql);
                }
            }
        }
    }
}