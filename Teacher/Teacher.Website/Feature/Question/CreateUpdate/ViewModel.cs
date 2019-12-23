using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teacher.Website.Feature.Question.CreateUpdate
{
    public class ViewModel
    {
        [BindProperty]
        public QuestionViewModel Question { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public ViewModel()
        {
            Question = new QuestionViewModel();
            Categories = new List<SelectListItem>();
        }

        public class QuestionViewModel
        {
            [Required]
            [HiddenInput]
            public int Id { get; set; }

            [Required]
            public int CategoryId { get; set; }

            [Required]
            [Display(Name = "Nazwa kategorii")]
            public string CategoryName { get; set; }

            [Required]
            [Display(Name = "Treść pytania")]
            public string Content { get; set; }

            [Display(Name = "Odpowiedź")]
            public string Answer { get; set; }
        }

        public class CategoryViewModel
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}