using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Teacher.Website.Feature.Interview.Answer
{
    public class PageFacade : IPageFacade
    {
        private readonly IMediator _mediator;

        public PageFacade(IMediator mediator)
            => _mediator = mediator;

        public async Task<ViewModel> OnGetAsync(Query query)
            => await _mediator.Send(query);

        public async Task<IActionResult> OnPostAsync(Command command)
        {
            await _mediator.Send(command);
            return new RedirectResult("/Interview/Answer");
        }
    }
}