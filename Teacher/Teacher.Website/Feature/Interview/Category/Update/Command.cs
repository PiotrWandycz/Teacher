using MediatR;

namespace Teacher.Website.Feature.Interview.Category.Update
{
    public class Command : IRequest
    {
        public ViewModel.CategoryViewModel Category { get; set; }
    }
}