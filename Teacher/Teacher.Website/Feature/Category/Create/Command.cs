using MediatR;

namespace Teacher.Website.Feature.Category.Create
{
    public class Command : IRequest
    {
        public ViewModel.CategoryViewModel Category { get; set; }
    }
}