using MediatR;

namespace Teacher.Website.Feature.Category.Delete
{
    public class Command : IRequest
    {
        public int Id { get; set; }
    }
}