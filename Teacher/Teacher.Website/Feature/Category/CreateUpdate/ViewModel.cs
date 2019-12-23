using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Teacher.Website.Feature.Category.CreateUpdate
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
            [Display()]
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }
        }
    }
}