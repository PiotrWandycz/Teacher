using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Teacher.Website.Infrastructure;
using Teacher.Website.Infrastructure.Database;

namespace Teacher.Website.Feature.Question.Create
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
                var sql = "SELECT [Id], [Name] FROM [Category]";
                return await db.QueryAsync<ViewModel.CategoryViewModel>(sql);
            }
        }

        public async Task CreateQuestionAsync(ViewModel.QuestionViewModel question)
        {
            var questionToAdd = new Infrastructure.Database.Question
            {
                CategoryId = question.CategoryId,
                Content = question.Content,
                Answer = question.Answer
            };
            await _dbContext.Question.AddAsync(questionToAdd);
            await _dbContext.SaveChangesAsync();
        }
    }
}