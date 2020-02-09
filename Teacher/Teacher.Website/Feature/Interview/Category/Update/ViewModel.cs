using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Teacher.Website.Feature.Interview.Category.Update
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
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }
        }
    }
}