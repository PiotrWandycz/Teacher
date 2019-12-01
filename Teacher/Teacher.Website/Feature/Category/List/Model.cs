using System.Collections.Generic;

namespace Teacher.Website.Feature.Category.List
{
    public class Model
    {
        public IEnumerable<CategoryModel> Categories { get; set; }

        public class CategoryModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}