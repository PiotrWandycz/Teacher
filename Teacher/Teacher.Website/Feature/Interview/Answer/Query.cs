using MediatR;

namespace Teacher.Website.Feature.Interview.Answer
{
    public class Query : IRequest<ViewModel>
    {
        public int UserId { get; set; }
    }
}