using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Teacher.Website.Feature.Interview.Answer
{
    public class IndexModel : PageModel
    {
        private readonly IPageFacade _facade;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IndexModel(IPageFacade facade,
            IHttpContextAccessor httpContextAccessor)
        {
            _facade = facade;
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]
        public ViewModel Data { get; set; }

        public async Task OnGetAsync(Query query)
        {
            var uid = _httpContextAccessor.HttpContext.User.FindFirst("UserId");
            query.UserId = int.Parse(uid.Value);
            Data = await _facade.OnGetAsync(query);

            if (Data.Answer.QuestionId == 0)
                _httpContextAccessor.HttpContext.Response.Redirect("/Interview/Problem");
        } 

        public async Task<IActionResult> OnPostAsync()
            => await _facade.OnPostAsync(new Command 
            {
                QuestionId = Data.Answer.QuestionId,
                UserId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("UserId").Value),
                WasAnswerCorrect = Data.Answer.WasAnswerCorrect
            });
    }
}