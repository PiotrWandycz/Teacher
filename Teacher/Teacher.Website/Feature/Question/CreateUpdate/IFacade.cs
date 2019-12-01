using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Teacher.Website.Feature.Question.CreateUpdate
{
    public interface IFacade
    {
        Task<Model> OnGetAsync(Query query);
        Task<IActionResult> OnPostAsync(Command command);
    }
}