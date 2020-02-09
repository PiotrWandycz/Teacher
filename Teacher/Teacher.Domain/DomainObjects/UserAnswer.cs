using System;

namespace Teacher.Domain.DomainObjects
{
    public class UserAnswer
    {
        public int QuestionId { get; }
        public DateTime AnsweredAt { get; }

        public UserAnswer(int questionId, DateTime answeredAt)
        {
            QuestionId = questionId;
            AnsweredAt = answeredAt;
        }
    }
}