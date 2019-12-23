using System.Threading.Tasks;
using Teacher.Website.Infrastructure;

namespace Teacher.Website.Feature.Question.List
{
    public interface IPageFacade : IPageFacadeMarker
    {
        Task<ViewModel> OnGetAsync(Query query);
    }
}