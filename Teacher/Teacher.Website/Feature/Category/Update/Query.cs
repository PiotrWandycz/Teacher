using MediatR;

namespace Teacher.Website.Feature.Category.Update
{
    public class Query : IRequest<ViewModel>
    {
        public int Id { get; set; }
    }
}