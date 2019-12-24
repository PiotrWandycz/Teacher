using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Linq;
using System.Text;

namespace Teacher.Website.Feature
{
    public class EnvironmentController : Controller
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public EnvironmentController(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        [HttpGet("/routes")]
        public IActionResult GetAllRoutes()
        {
            // get all available routes
            var routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items.Where(ad => ad.AttributeRouteInfo != null).OrderBy(x => x.AttributeRouteInfo.Template).ToList();

            // omit Identity
            routes = routes.Where(x => !x.AttributeRouteInfo.Template.StartsWith("Identity/")).ToList();

            // build response content
            var sb = new StringBuilder();
            sb.Append($@"<html><head><meta charset='utf-8'><title>Routes</title>
                <style>
                p, li {{
                    font-family: 'Verdana', sans-serif;
                    font-weight: 600;
                }}
                .val {{
                        font-family: 'Courier New', Courier, monospace;
                }}
                </style>
                </style></head><body>");
            sb.Append($"<p>{routes.Count} routes found<p>");
            sb.Append("<ul>");

            foreach (var route in routes)
            {
                sb.Append($"<li><span class='val'>{route.AttributeRouteInfo.Template}</span></span></li>");
            }
            sb.Append("</ul></body></html>");
            var content = sb.ToString();

            return new ContentResult
            {
                Content = content,
                ContentType = "text/html"
            };
        }
    }
}