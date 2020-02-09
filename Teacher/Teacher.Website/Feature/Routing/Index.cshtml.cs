using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Teacher.Website.Feature.Routing
{
    public class IndexModel : PageModel
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public IndexModel(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        [BindProperty]
        public ViewModel Data { get; set; } 

        public void OnGet(bool noIndex = false)
        {
            Data = new ViewModel();
            var allRoutes = _actionDescriptorCollectionProvider.ActionDescriptors.Items.Where(ad => ad.AttributeRouteInfo != null).OrderBy(x => x.AttributeRouteInfo.Template).ToList();
            Data.Routes = noIndex == true ? 
                allRoutes.Where(x => !x.AttributeRouteInfo.Template.StartsWith("Identity/") && !x.AttributeRouteInfo.Template.Contains("Index")).ToList()
                : allRoutes.Where(x => !x.AttributeRouteInfo.Template.StartsWith("Identity/")).ToList();
        }
    }
}