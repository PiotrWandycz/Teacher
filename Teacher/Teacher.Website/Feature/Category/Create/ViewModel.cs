using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Teacher.Website.Feature.Category.Create
{
    public class ViewModel
    {
        [BindProperty]
        public CategoryViewModel Category { get; set; }

        public ViewModel()
        {
            Category = new CategoryViewModel();
        }

        public class CategoryViewModel
        {
            [Required]
            [Display(Name = "Nazwa")]
            public string Name { get; set; }
        }
    }
}