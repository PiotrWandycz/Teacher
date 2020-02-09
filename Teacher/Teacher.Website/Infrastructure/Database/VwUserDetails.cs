using System;
using System.Collections.Generic;

namespace Teacher.Website.Infrastructure.Database
{
    public partial class VwUserDetails
    {
        public string AspNetUserId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
