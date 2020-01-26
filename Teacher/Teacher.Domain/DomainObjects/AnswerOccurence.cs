using System;
using System.Collections.Generic;

namespace Teacher.Domain.DomainObjects
{
    public class AnswerOccurence
    {
        public int QuestionId { get; }
        public int AnsweredTimes { get; private set; }
        public List<DateTime> AnsweredDates { get; }

        public AnswerOccurence(int questionId, DateTime answeredAt)
        {
            QuestionId = questionId;
            AnsweredTimes = 1;
            AnsweredDates = new List<DateTime> { answeredAt };
        }

        public void AddOccurence(DateTime answeredAt)
        {
            AnsweredTimes++;
            AnsweredDates.Add(answeredAt);
        }
    }
}