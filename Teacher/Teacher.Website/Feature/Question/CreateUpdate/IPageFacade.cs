using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Teacher.Website.Infrastructure;

namespace Teacher.Website.Feature.Question.CreateUpdate
{
    public interface IPageFacade : IPageFacadeMarker
    {
        Task<ViewModel> OnGetAsync(Query query);
        Task<IActionResult> OnPostAsync(Command command);
    }
}