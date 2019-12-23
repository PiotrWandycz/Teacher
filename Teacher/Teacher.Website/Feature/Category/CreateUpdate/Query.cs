using MediatR;

namespace Teacher.Website.Feature.Category.CreateUpdate
{
    public class Query : IRequest<ViewModel>
    {
        public int? Id { get; set; }
    }
}