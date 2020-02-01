using System;
using System.Collections.Generic;

namespace Teacher.Website.Infrastructure.Database
{
    public partial class User
    {
        public User()
        {
            Answer = new HashSet<Answer>();
        }

        public int Id { get; set; }
        public string AspNetUserId { get; set; }

        public virtual AspNetUsers AspNetUser { get; set; }
        public virtual ICollection<Answer> Answer { get; set; }
    }
}
