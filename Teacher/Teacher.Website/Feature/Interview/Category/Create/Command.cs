using MediatR;

namespace Teacher.Website.Feature.Interview.Category.Create
{
    public class Command : IRequest
    {
        public ViewModel.CategoryInputModel Category { get; set; }
    }
}