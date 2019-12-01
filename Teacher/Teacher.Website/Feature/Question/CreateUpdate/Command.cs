using MediatR;

namespace Teacher.Website.Feature.Question.CreateUpdate
{
    public class Command : IRequest<Unit>
    {
        public Model.QuestionModel Question { get; set; }
    }
}