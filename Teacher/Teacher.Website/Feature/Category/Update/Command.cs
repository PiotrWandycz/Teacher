using MediatR;

namespace Teacher.Website.Feature.Category.Update
{
    public class Command : IRequest<Unit>
    {
        public ViewModel.CategoryViewModel Category { get; set; }
    }
}