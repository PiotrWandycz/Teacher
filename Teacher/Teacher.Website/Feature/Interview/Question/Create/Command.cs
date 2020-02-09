using MediatR;

namespace Teacher.Website.Feature.Interview.Question.Create
{
    public class Command : IRequest
    {
        public ViewModel.QuestionInputModel Question { get; set; }
    }
}