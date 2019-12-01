using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Teacher.Website.Enums;
using Teacher.Website.Infrastructure.Database;

namespace Teacher.Website.Feature.Question
{
    public class CreateUpdateModel : PageModel
    {
        private readonly IMediator _mediator;

        public CreateUpdateModel(IMediator mediator) 
            => _mediator = mediator;

        public Model Data { get; private set; }

        public async Task OnGetAsync(Query query) 
            => Data = await _mediator.Send(query);

        public class Query : IRequest<Model>
        {
            public int? QuestionId { get; set; }
        }

        public class Model
        {
            [BindProperty]
            public QuestionModel Question { get; set; }

            public List<SelectListItem> Categories { get; set; }

            public Model()
            {
                Question = new QuestionModel();
                Categories = new List<SelectListItem>();
            }

            public class QuestionModel
            {
                [Required]
                [HiddenInput]
                public int QuestionId { get; set; }

                [Required]
                public int CategoryId { get; set; }

                [Required]
                [Display(Name = "Nazwa kategorii")]
                public string CategoryName { get; set; }

                [Required]
                [Display(Name = "Treść pytania")]
                public string Content { get; set; }

                [Display(Name = "Odpowiedź junior")]
                public string AnswerJunior { get; set; }

                [Display(Name = "Odpowiedź regular")]
                public string AnswerRegular { get; set; }

                [Display(Name = "Odpowiedź senior")]
                public string AnswerSenior { get; set; }

                public QuestionLevel Level { get; set; }
            }

            public class CategoryModel
            {
                public int Id { get; set; }

                public string Name { get; set; }
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
                model.Categories = await GetCategories(_configuration).ContinueWith(x => MapCategories(x.Result));
                if (!query.QuestionId.HasValue)
                    return model;
                model.Question = await GetQuestion(_configuration, query.QuestionId.Value);
                MarkCategorySelected(model);
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
                using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
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

        public async Task<IActionResult> OnPostAsync()
        {
            var command = new Command { Question = Data.Question };
            await _mediator.Send(command);
            return RedirectToPage("List");
        }

        private class Command : IRequest<Unit>
        {
            public Model.QuestionModel Question { get; set; }
        }

        private class CommandHandler : IRequestHandler<Command, Unit>
        {
            private readonly TeacherContext _dbContext;

            public CommandHandler(TeacherContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
            {
                if (!string.IsNullOrWhiteSpace(command.Question.AnswerJunior))
                    command.Question.Level = QuestionLevel.Junior;
                if (!string.IsNullOrWhiteSpace(command.Question.AnswerRegular))
                    command.Question.Level = QuestionLevel.Junior | QuestionLevel.Regular;
                if (!string.IsNullOrWhiteSpace(command.Question.AnswerSenior))
                    command.Question.Level = QuestionLevel.Junior | QuestionLevel.Regular | QuestionLevel.Senior;

                var question = await _dbContext.Question.FindAsync(command.Question.QuestionId);
                if (question is null)
                {
                    question = new Infrastructure.Database.Question();
                    await _dbContext.Question.AddAsync(question, cancellationToken);
                }
                question.Content = command.Question.Content;
                question.CategoryId = command.Question.CategoryId;
                question.Level = (byte)command.Question.Level;
                question.AnswerJunior = command.Question.AnswerJunior;
                question.AnswerRegular = command.Question.AnswerRegular;
                question.AnswerSenior = command.Question.AnswerSenior;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}