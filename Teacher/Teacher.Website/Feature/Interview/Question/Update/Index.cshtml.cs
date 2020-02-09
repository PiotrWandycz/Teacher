using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Teacher.Website.Feature.Interview.Question.Update
{
    public class IndexModel : PageModel
    {
        private readonly IPageFacade _facade;

        public IndexModel(IPageFacade facade)
            => _facade = facade;

        [BindProperty]
        public ViewModel Data { get; set; }

        public async Task OnGetAsync(Query query)
            => Data = await _facade.OnGetAsync(query);

        public async Task<IActionResult> OnPostAsync()
            => await _facade.OnPostAsync(new Command { Question = Data.Question });
    }
}