using MediatR;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Teacher.Website.Feature.Tests")]
namespace Teacher.Website.Feature.Interview.Category.Create
{
    internal class QueryHandler : IRequestHandler<Query, ViewModel>
    {
        public async Task<ViewModel> Handle(Query query, CancellationToken cancellationToken)
        {
            return new ViewModel();
        }
    }
}