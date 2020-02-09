using MediatR;

namespace Teacher.Website.Feature.Interview.Category.Update
{
    public class Command : IRequest
    {
        public ViewModel.CategoryInputModel Category { get; set; }
    }
}