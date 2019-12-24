using MediatR;

namespace Teacher.Website.Feature.Category.Create
{
    public class Command : IRequest<Unit>
    {
        public ViewModel.CategoryViewModel Category { get; set; }
    }
}