using Microsoft.AspNetCore.Mvc.Abstractions;
using System.Collections.Generic;

namespace Teacher.Website.Feature.Routing
{
    public class ViewModel
    {
        public List<ActionDescriptor> Routes { get; set; }

        public ViewModel()
        {
            Routes = new List<ActionDescriptor>();
        }
    }
}
