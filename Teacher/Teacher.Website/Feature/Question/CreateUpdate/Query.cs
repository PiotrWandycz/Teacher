using MediatR;

namespace Teacher.Website.Feature.Question.CreateUpdate
{
    public class Query : IRequest<ViewModel>
    {
        public int? Id { get; set; }
    }
}