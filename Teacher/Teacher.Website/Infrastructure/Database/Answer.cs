using System;
using System.Collections.Generic;

namespace Teacher.Website.Infrastructure.Database
{
    public partial class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public DateTime AnsweredAt { get; set; }
        public bool WasAnswerCorrect { get; set; }

        public virtual Question Question { get; set; }
        public virtual User User { get; set; }
    }
}
