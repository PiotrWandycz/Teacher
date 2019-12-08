using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Teacher.Website.Enums;

[assembly: InternalsVisibleTo("Teacher.Website.Feature.Tests")]
namespace Teacher.Website.Feature.Question.List
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
            model.Questions = await GetQuestions(_configuration, query.Type);
            return model;
        }

        private async Task<IEnumerable<Model.QuestionModel>> GetQuestions(IConfiguration configuration, QuestionType type)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
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
            using (var db = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
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