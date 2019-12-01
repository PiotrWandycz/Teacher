using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Teacher.Website.Enums;

namespace Teacher.Website.Feature.Question
{
    public class ListModel : PageModel
    {
        private readonly IMediator _mediator;

        public ListModel(IMediator mediator)
            => _mediator = mediator;

        public Model Data { get; private set; }

        public async Task OnGetAsync(Query query)
            => Data = await _mediator.Send(query);

        public class Query : IRequest<Model>
        {
            public QuestionType Type { get; set; }
        }

        public class Model
        {
            public IEnumerable<QuestionModel> Questions { get; set; }

            public class QuestionModel
            {
                public int Id { get; set; }
                public string Content { get; set; }
            }
        }

        public class QueryHandler : IRequestHandler<Query, Model>
        {
            private readonly IConfiguration _configuration;

            public QueryHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task<Model> Handle(Query query, CancellationToken cancellationToken)
            {
                var model = new Model();
                model.Questions = await GetQuestions(_configuration, query.Type);
                return model;
            }

            private async Task<IEnumerable<Model.QuestionModel>> GetQuestions(IConfiguration configuration, QuestionType type)
            {
                using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var sql = string.Empty;
                    if (type == QuestionType.All)
                    {
                        sql = "SELECT [Id], [Content] FROM [Question]";
                    }
                    else if (type == QuestionType.NotAnswered)
                    {
                        sql = "SELECT [Id], [Content] FROM [Question] WHERE [Level] = 0";
                    }
                    return await db.QueryAsync<Model.QuestionModel>(sql);
                }
            }

            private async Task<IEnumerable<vw_QuestionList>> GetQuestionsNew(IConfiguration configuration, QuestionType type)
            {
                using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var sql = string.Empty;
                    if (type == QuestionType.All)
                    {
                        sql = $"SELECT * FROM [vw_QuestionList]";
                    }
                    else if (type == QuestionType.NotAnswered)
                    {
                        sql = $"SELECT * FROM [vw_QuestionList] WHERE [Level] = 0";
                    }
                    return await db.QueryAsync<vw_QuestionList>(sql);
                }
            }

            private class vw_QuestionList
            {
                public int QuestionId { get; set; }
                public int CategoryId { get; set; }
                public string CategoryName { get; set; }
                public string Content { get; set; }
                public byte Level { get; set; }
            }
        }
    }
}