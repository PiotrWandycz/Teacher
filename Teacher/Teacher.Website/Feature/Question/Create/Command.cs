using MediatR;

namespace Teacher.Website.Feature.Question.Create
{
    public class Command : IRequest
    {
        public ViewModel.QuestionViewModel Question { get; set; }
    }
}