using MediatR;

namespace Teacher.Website.Feature.Category.Update
{
    public class Command : IRequest
    {
        public ViewModel.CategoryViewModel Category { get; set; }
    }
}