using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Teacher.Website.Infrastructure;

namespace Teacher.Website.Feature.Interview.Question.Delete
{
    public interface IPageFacade : IPageFacadeMarker
    {
        Task<IActionResult> OnGetAsync(Command command);
    }
}