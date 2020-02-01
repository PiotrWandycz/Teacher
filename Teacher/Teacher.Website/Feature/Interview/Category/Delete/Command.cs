using MediatR;

namespace Teacher.Website.Feature.Interview.Category.Delete
{
    public class Command : IRequest
    {
        public int Id { get; set; }
    }
}