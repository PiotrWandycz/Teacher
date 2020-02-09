using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Teacher.Website.Feature.Interview.Category.Create
{
    public class ViewModel
    {
        [BindProperty]
        public CategoryInputModel Category { get; set; }

        public ViewModel()
        {
            Category = new CategoryInputModel();
        }

        public class CategoryInputModel
        {
            [Required]
            [Display(Name = "Nazwa")]
            public string Name { get; set; }
        }
    }
}