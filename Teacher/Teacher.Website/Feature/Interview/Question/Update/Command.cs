using MediatR;

namespace Teacher.Website.Feature.Interview.Question.Update
{
    public class Command : IRequest
    {
        public ViewModel.QuestionInputModel Question { get; set; }
    }
}