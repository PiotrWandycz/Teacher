using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Teacher.Website.Feature.Interview.Category.Create
{
    public class IndexModel : PageModel
    {
        private readonly IPageFacade _pageFacade;

        public IndexModel(IPageFacade pageFacade)
            => _pageFacade = pageFacade;

        [BindProperty]
        public ViewModel Data { get; set; }

        public async Task OnGetAsync(Query query)
            => Data = await _pageFacade.OnGetAsync(query);

        public async Task<IActionResult> OnPostAsync()
            => await _pageFacade.OnPostAsync(new Command { Category = Data.Category });
    }
}