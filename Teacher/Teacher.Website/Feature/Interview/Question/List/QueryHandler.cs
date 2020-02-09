using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Teacher.Website.Feature.Tests")]
namespace Teacher.Website.Feature.Interview.Question.List
{
    internal class QueryHandler : IRequestHandler<Query, ViewModel>
    {
        private readonly IRepository _repository;

        public QueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ViewModel> Handle(Query query, CancellationToken cancellationToken)
        {
            var model = new ViewModel();
            var questions = await _repository.GetQuestionsAsync();
            model.Questions = MapQuestions(questions);
            return model;
        }

        private IEnumerable<ViewModel.QuestionReadModel> MapQuestions(IEnumerable<vw_QuestionDetails> questions)
        {
            return questions.Select(x => new ViewModel.QuestionReadModel
            {
                Id = x.QuestionId,
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Content = x.Content,
                HasMissingAnswer = x.Answer is null
            }).ToList();
        }
    }
}