using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Teacher.Website.Feature.Category.Delete
{
    public class IndexModel : PageModel
    {
        private readonly IPageFacade _pageFacade;

        public IndexModel(IPageFacade pageFacade)
            => _pageFacade = pageFacade;

        public async Task<IActionResult> OnGetAsync(Command command)
            => await _pageFacade.OnGetAsync(command);
    }
}