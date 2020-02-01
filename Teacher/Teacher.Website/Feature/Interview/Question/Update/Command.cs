using MediatR;

namespace Teacher.Website.Feature.Interview.Question.Update
{
    public class Command : IRequest
    {
        public ViewModel.QuestionViewModel Question { get; set; }
    }
}