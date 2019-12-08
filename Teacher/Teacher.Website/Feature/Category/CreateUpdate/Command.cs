using MediatR;

namespace Teacher.Website.Feature.Category.CreateUpdate
{
    public class Command : IRequest<Unit>
    {
        public ViewModel.CategoryViewModel Category { get; set; }
    }
}