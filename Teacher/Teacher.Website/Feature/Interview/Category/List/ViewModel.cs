using System.Collections.Generic;

namespace Teacher.Website.Feature.Interview.Category.List
{
    public class ViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public ViewModel()
        {
            Categories = new List<CategoryViewModel>();
        }

        public class CategoryViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}