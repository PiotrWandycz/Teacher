using System;
using System.Collections.Generic;

namespace Teacher.Website.Infrastructure.Database
{
    public partial class Learning
    {
        public Learning()
        {
            LearningQuestion = new HashSet<LearningQuestion>();
            Statistics = new HashSet<Statistics>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<LearningQuestion> LearningQuestion { get; set; }
        public virtual ICollection<Statistics> Statistics { get; set; }
    }
}
