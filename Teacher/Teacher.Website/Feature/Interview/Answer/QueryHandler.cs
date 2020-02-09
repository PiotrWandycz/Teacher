using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Teacher.Domain.CalculateAnswerOccurences;
using Teacher.Domain.DomainObjects;
using Teacher.Domain.SelectQuestions;

[assembly: InternalsVisibleTo("Teacher.Website.Feature.Tests")]
namespace Teacher.Website.Feature.Interview.Answer
{
    internal class QueryHandler : IRequestHandler<Query, ViewModel>
    {
        private readonly IRepository _repository;
        private readonly IQuestionSelector _questionSelector;
        private readonly IAnswerOccurenceCalculator _answerOccurenceCalculator;

        public QueryHandler(IRepository repository, 
            IQuestionSelector questionSelector, 
            IAnswerOccurenceCalculator answerOccurenceCalculator)
        {
            _repository = repository;
            _questionSelector = questionSelector;
            _answerOccurenceCalculator = answerOccurenceCalculator;
        }

        public async Task<ViewModel> Handle(Query query, CancellationToken cancellationToken)
        {
            var model = new ViewModel();
            var questionIds = await _repository.GetQuestionIdsThatHasAnswerAsync();
            var answersDb = await _repository.GetAnswersAsync(query.UserId);
            var answers = MapAnswers(answersDb);
            var occurences = _answerOccurenceCalculator.GetData(answers);
            var nextQuestionId = _questionSelector.GetNextQuestionId(questionIds, occurences);
            var questionDb = await _repository.GetQuestionAsync(nextQuestionId);
            model.Question = MapQuestion(questionDb);
            model.Answer.QuestionId = model.Question.Id;
            return model;
        }

        private IEnumerable<UserAnswer> MapAnswers(IEnumerable<AnswerReadModel> answersReadModel)
        {
            return answersReadModel.Select(x => new UserAnswer(x.QuestionId, x.AnsweredAt));
        }

        private QuestionReadModel MapQuestion(vw_QuestionDetails question)
        {
            return new QuestionReadModel
            {
                Id = question.QuestionId,
                CategoryName = question.CategoryName,
                Content = question.Content,
                Answer = question.Answer
            };
        }
    }
}