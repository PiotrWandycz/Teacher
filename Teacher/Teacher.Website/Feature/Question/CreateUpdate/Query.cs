using MediatR;

namespace Teacher.Website.Feature.Question.CreateUpdate
{
    public class Query : IRequest<Model>
    {
        public int? QuestionId { get; set; }
    }
}