using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teacher.Website.Feature.Interview.Question.Update
{
    public class ViewModel
    {
        public List<SelectListItem> Categories { get; set; }

        [BindProperty]
        public QuestionInputModel Question { get; set; }

        public ViewModel()
        {
            Categories = new List<SelectListItem>();
            Question = new QuestionInputModel();
        }

        public class QuestionInputModel
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

        public class CategoryReadModel
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}