using System.Threading.Tasks;
using MediatR;

namespace Teacher.Website.Feature.Question.List
{
    public class Facade : IFacade
    {
        private readonly IMediator _mediator;

        public Facade(IMediator mediator)
            => _mediator = mediator;

        public async Task<Model> OnGetAsync(Query query)
            => await _mediator.Send(query);
    }
}