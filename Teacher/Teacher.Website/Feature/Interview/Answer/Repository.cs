using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Teacher.Website.Infrastructure;

namespace Teacher.Website.Feature.Interview.Answer
{
    class Repository : IRepository
    {
        private readonly IConnectionStringFactory _connectionStringFactory;

        public Repository(IConnectionStringFactory connectionStringFactory)
        {
            _connectionStringFactory = connectionStringFactory;
        }

        public async Task<IEnumerable<int>> GetQuestionIdsAsync()
        {
            using (var db = new SqlConnection(_connectionStringFactory.ToDatabase()))
            {
                var sql = $"SELECT Id FROM [Question]";
                return await db.QueryAsync<int>(sql);
            }
        }

        public async Task<IEnumerable<AnswerReadModel>> GetAnswersAsync(int userId)
        {
            using (var db = new SqlConnection(_connectionStringFactory.ToDatabase()))
            {
                var sql = $"SELECT Id, QuestionId, UserId, AnsweredAt FROM [Answer]";
                return await db.QueryAsync<AnswerReadModel>(sql);
            }
        }

        public async Task<vw_QuestionDetails> GetQuestionAsync(int questionId)
        {
            using (var db = new SqlConnection(_connectionStringFactory.ToDatabase()))
            {
                var sql = $"SELECT * FROM [vw_QuestionDetails] WHERE [QuestionId] = { questionId }";
                return await db.QueryFirstAsync<vw_QuestionDetails>(sql);
            }
        }

        public Task CreateAnswerAsync(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}