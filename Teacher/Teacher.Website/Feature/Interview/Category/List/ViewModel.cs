using System.Collections.Generic;

namespace Teacher.Website.Feature.Interview.Category.List
{
    public class ViewModel
    {
        public IEnumerable<CategoryInputModel> Categories { get; set; }

        public ViewModel()
        {
            Categories = new List<CategoryInputModel>();
        }

        public class CategoryInputModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}