using MediatR;

namespace Teacher.Website.Feature.Interview.Question.Create
{
    public class Command : IRequest
    {
        public ViewModel.QuestionViewModel Question { get; set; }
    }
}