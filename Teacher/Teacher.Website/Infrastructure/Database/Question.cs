using System;
using System.Collections.Generic;

namespace Teacher.Website.Infrastructure.Database
{
    public partial class Question
    {
        public Question()
        {
            AnswerNavigation = new HashSet<Answer>();
        }

        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Content { get; set; }
        public string Answer { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Answer> AnswerNavigation { get; set; }
    }
}
