using MediatR;

namespace Teacher.Website.Feature.Question.CreateUpdate
{
    public class Command : IRequest<Unit>
    {
        public ViewModel.QuestionViewModel Question { get; set; }
    }
}