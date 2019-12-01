using System.Collections.Generic;

namespace Teacher.Website.Feature.Question.List
{
    public class Model
    {
        public IEnumerable<QuestionModel> Questions { get; set; }

        public class QuestionModel
        {
            public int Id { get; set; }
            public string Content { get; set; }
        }
    }
}