using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Teacher.Website.Infrastructure;
using Teacher.Website.Infrastructure.Database;

namespace Teacher.Website.Feature.Interview.Question.Update
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

        public async Task<IEnumerable<ViewModel.CategoryViewModel>> GetCategoriesAsync()
        {
            using (var db = new SqlConnection(_connectionStringFactory.ToDatabase()))
            {
                var sql = "SELECT [Id], [Name] FROM [Interview].[Category]";
                return await db.QueryAsync<ViewModel.CategoryViewModel>(sql);
            }
        }

        public async Task<ViewModel.QuestionViewModel> GetQuestionAsync(int questionId)
        {
            using (var db = new SqlConnection(_connectionStringFactory.ToDatabase()))
            {
                var sql = $"SELECT * FROM [Interview].[vw_QuestionDetails] WHERE [QuestionId] = { questionId }";
                return await db.QueryFirstAsync<ViewModel.QuestionViewModel>(sql);
            }
        }

        public async Task UpdateQuestionAsync(ViewModel.QuestionViewModel question)
        {
            var questionToUpdate = await _dbContext.Question.FindAsync(question.Id);
            if (questionToUpdate is null)
            {
                questionToUpdate = new Infrastructure.Database.Question();
                await _dbContext.Question.AddAsync(questionToUpdate);
                await _dbContext.SaveChangesAsync();
            }
            questionToUpdate.CategoryId = question.CategoryId;
            questionToUpdate.Content = question.Content;              
            questionToUpdate.Answer = question.Answer;
            await _dbContext.SaveChangesAsync();
        }
    }
}