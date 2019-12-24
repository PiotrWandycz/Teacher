using MediatR;

namespace Teacher.Website.Feature.Category.Delete
{
    public class Command : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}