using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Teacher.Website.Feature.Category.Delete
{
    class PageFacade : IPageFacade
    {
        private readonly IMediator _mediator;

        public PageFacade(IMediator mediator)
            => _mediator = mediator;

        public async Task<IActionResult> OnGetAsync(Command command)
        {
            await _mediator.Send(command);
            return new RedirectResult("/Category/List");
        }
    }
}