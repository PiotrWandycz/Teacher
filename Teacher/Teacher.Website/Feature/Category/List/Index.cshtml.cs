using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Teacher.Website.Feature.Category.List
{
    public class IndexModel : PageModel
    {
        private readonly IFacade _facade;

        public IndexModel(IFacade facade)
            => _facade = facade;

        [BindProperty]
        public Model Data { get; set; }

        public async Task OnGetAsync(Query query)
            => Data = await _facade.OnGetAsync(query);
    }
}