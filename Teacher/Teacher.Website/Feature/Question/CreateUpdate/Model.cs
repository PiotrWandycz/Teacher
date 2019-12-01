using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Teacher.Website.Enums;

namespace Teacher.Website.Feature.Question.CreateUpdate
{
    public class Model
    {
        [BindProperty]
        public QuestionModel Question { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public Model()
        {
            Question = new QuestionModel();
            Categories = new List<SelectListItem>();
        }

        public class QuestionModel
        {
            [Required]
            [HiddenInput]
            public int QuestionId { get; set; }

            [Required]
            public int CategoryId { get; set; }

            [Required]
            [Display(Name = "Nazwa kategorii")]
            public string CategoryName { get; set; }

            [Required]
            [Display(Name = "Treść pytania")]
            public string Content { get; set; }

            [Display(Name = "Odpowiedź junior")]
            public string AnswerJunior { get; set; }

            [Display(Name = "Odpowiedź regular")]
            public string AnswerRegular { get; set; }

            [Display(Name = "Odpowiedź senior")]
            public string AnswerSenior { get; set; }

            public QuestionLevel Level { get; set; }
        }

        public class CategoryModel
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}