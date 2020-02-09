using System.Collections.Generic;

namespace Teacher.Website.Feature.Interview.Question.List
{
    public class ViewModel
    {
        public IEnumerable<QuestionReadModel> Questions { get; set; }

        public ViewModel()
        {
            Questions = new List<QuestionReadModel>();
        }

        public class QuestionReadModel
        {
            public int Id { get; set; }
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
            public string Content { get; set; }
            public bool HasMissingAnswer { get; set; }
        }
    }
}