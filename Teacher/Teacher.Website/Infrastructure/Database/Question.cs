using System.Collections.Generic;

namespace Teacher.Website.Infrastructure.Database
{
    public partial class Question
    {
        public Question()
        {
            LearningQuestion = new HashSet<LearningQuestion>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Content { get; set; }
        public byte Level { get; set; }
        public string AnswerJunior { get; set; }
        public string AnswerRegular { get; set; }
        public string AnswerSenior { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<LearningQuestion> LearningQuestion { get; set; }
    }
}
