using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Teacher.Website.Feature.Interview.Answer
{
    public class ViewModel
    {
        public QuestionReadModel Question { get; set; }

        public AnswerViewModel Answer { get; set;}

        public ViewModel()
        {
            Question = new QuestionReadModel();
            Answer = new AnswerViewModel();
        }
    }

    public class QuestionReadModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string Content { get; set; }

        public string Answer { get; set; }
    }


    public class AnswerViewModel
    {
        [HiddenInput]
        [Required]
        public int QuestionId { get; set; }

        public bool WasAnswerCorrect { get; set; }
    }   

    public class AnswerReadModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public DateTime AnsweredAt { get; set; }
    }
}