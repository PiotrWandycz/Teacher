using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Teacher.Website.Feature.Category.CreateUpdate
{
    public class Facade : IFacade
    {
        private readonly IMediator _mediator;

        public Facade(IMediator mediator)
            => _mediator = mediator;

        public async Task<Model> OnGetAsync(Query query)
            => await _mediator.Send(query);

        public async Task<IActionResult> OnPostAsync(Command command)
        {
            await _mediator.Send(command);
            return new RedirectToPageResult("List");
        }
    }
}