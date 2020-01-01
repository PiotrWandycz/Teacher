using MediatR;

namespace Teacher.Website.Feature.Question.Update
{
    public class Command : IRequest
    {
        public ViewModel.QuestionViewModel Question { get; set; }
    }
}