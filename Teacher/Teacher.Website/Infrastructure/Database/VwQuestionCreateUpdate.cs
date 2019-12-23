using System;
using System.Collections.Generic;

namespace Teacher.Website.Infrastructure.Database
{
    public partial class VwQuestionCreateUpdate
    {
        public int QuestionId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Content { get; set; }
        public string Answer { get; set; }
    }
}
