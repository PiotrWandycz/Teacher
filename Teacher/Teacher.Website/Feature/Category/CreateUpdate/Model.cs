using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Teacher.Website.Feature.Category.CreateUpdate
{
    public class Model
    {
        [BindProperty]
        public CategoryModel Category { get; set; }

        public Model()
        {
            Category = new CategoryModel();
        }

        public class CategoryModel
        {
            [Required]
            [Display()]
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }
        }
    }
}