using MediatR;
using Teacher.Website.Enums;

namespace Teacher.Website.Feature.Question.List
{
    public class Query : IRequest<Model>
    {
        public QuestionType Type { get; set; }
    }
}