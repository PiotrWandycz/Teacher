using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Teacher.Website.Infrastructure;
using Teacher.Website.Infrastructure.Database;

namespace Teacher.Website.Feature.Interview.Answer
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

        public async Task<IEnumerable<int>> GetQuestionIdsThatHasAnswerAsync()
        {
            using (var db = new SqlConnection(_connectionStringFactory.ToDatabase()))
            {
                var sql = $"SELECT Id FROM [Interview].[Question] WHERE [Answer] IS NOT NULL";
                return await db.QueryAsync<int>(sql);
            }
        }

        public async Task<IEnumerable<AnswerReadModel>> GetAnswersAsync(int userId)
        {
            using (var db = new SqlConnection(_connectionStringFactory.ToDatabase()))
            {
                var sql = $"SELECT Id, QuestionId, UserId, AnsweredAt FROM [Interview].[Answer]";
                return await db.QueryAsync<AnswerReadModel>(sql);
            }
        }

        public async Task<vw_QuestionDetails> GetQuestionAsync(int questionId)
        {
            using (var db = new SqlConnection(_connectionStringFactory.ToDatabase()))
            {
                var sql = $"SELECT * FROM [Interview].[vw_QuestionDetails] WHERE [QuestionId] = { questionId }";
                return await db.QueryFirstAsync<vw_QuestionDetails>(sql);
            }
        }

        public async Task CreateAnswerAsync(Command command)
        {
            var answer = new Infrastructure.Database.Answer
            {
                QuestionId = command.QuestionId,
                UserId = command.UserId,
                WasAnswerCorrect = command.WasAnswerCorrect,
                AnsweredAt = DateTime.UtcNow
            };
            await _dbContext.Answer.AddAsync(answer);
            await _dbContext.SaveChangesAsync();
        }
    }
}