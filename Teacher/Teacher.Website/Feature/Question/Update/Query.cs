using MediatR;

namespace Teacher.Website.Feature.Question.Update
{
    public class Query : IRequest<ViewModel>
    {
        public int Id { get; set; }
    }
}