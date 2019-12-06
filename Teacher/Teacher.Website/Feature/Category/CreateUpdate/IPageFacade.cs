using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Teacher.Website.Feature.Category.CreateUpdate
{
    public interface IPageFacade
    {
        Task<Model> OnGetAsync(Query query);
        Task<IActionResult> OnPostAsync(Command command);
    }
}