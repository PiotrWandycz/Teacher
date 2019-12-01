using MediatR;

namespace Teacher.Website.Feature.Category.CreateUpdate
{
    public class Query : IRequest<Model>
    {
        public int? CategoryId { get; set; }
    }
}