using Dapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Teacher.Website.Feature.Tests")]
namespace Teacher.Website.Feature.Question.CreateUpdate
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
            model.Categories = await GetCategories(_configuration).ContinueWith(x => MapCategories(x.Result));
            if (!query.QuestionId.HasValue)
                return model;
            model.Question = await GetQuestion(_configuration, query.QuestionId.Value);
            MarkCategorySelected(model);
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

        private List<SelectListItem> MapCategories(IEnumerable<Model.CategoryModel> categories)
        {
            return categories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }

        private async Task<Model.QuestionModel> GetQuestion(IConfiguration configuration, int questionId)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
            {
                var sql = $"SELECT * FROM [vw_QuestionCreateUpdate] WHERE [QuestionId] = { questionId }";
                return await db.QueryFirstAsync<Model.QuestionModel>(sql);
            }
        }

        private void MarkCategorySelected(Model model)
        {
            var cat = model.Categories.FirstOrDefault(x => x.Value == model.Question.CategoryId.ToString());
            if (cat != null)
                cat.Selected = true;
        }
    }
}