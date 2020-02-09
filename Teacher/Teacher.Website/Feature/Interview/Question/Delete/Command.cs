using MediatR;

namespace Teacher.Website.Feature.Interview.Question.Delete
{
    public class Command : IRequest
    {
        public int Id { get; set; }
    }
}