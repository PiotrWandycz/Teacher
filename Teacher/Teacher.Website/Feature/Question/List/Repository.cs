using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Teacher.Website.Infrastructure;

namespace Teacher.Website.Feature.Question.List
{
    class Repository : IRepository
    {
        private readonly IConnectionStringFactory _connectionStringFactory;

        public Repository(IConnectionStringFactory connectionStringFactory)
        {
            _connectionStringFactory = connectionStringFactory;
        }

        public async Task<IEnumerable<vw_QuestionList>> GetQuestionsAsync()
        {
            using (var db = new SqlConnection(_connectionStringFactory.ToDatabase()))
            {
                var sql = "SELECT * FROM [vw_QuestionList]";
                return await db.QueryAsync<vw_QuestionList>(sql);
            }
        }
    }
}