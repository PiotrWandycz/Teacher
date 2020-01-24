using System;
using System.Collections.Generic;

namespace Teacher.Website.Infrastructure.Database
{
    public partial class Statistics
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LearningId { get; set; }
        public DateTime Date { get; set; }
        public int QuestionsAnswered { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }

        public virtual Learning Learning { get; set; }
        public virtual User User { get; set; }
    }
}
