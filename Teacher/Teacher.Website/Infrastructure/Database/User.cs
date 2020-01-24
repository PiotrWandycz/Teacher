using System;
using System.Collections.Generic;

namespace Teacher.Website.Infrastructure.Database
{
    public partial class User
    {
        public User()
        {
            Learning = new HashSet<Learning>();
            Statistics = new HashSet<Statistics>();
        }

        public int Id { get; set; }
        public string AspNetUserId { get; set; }

        public virtual AspNetUsers AspNetUser { get; set; }
        public virtual ICollection<Learning> Learning { get; set; }
        public virtual ICollection<Statistics> Statistics { get; set; }
    }
}
