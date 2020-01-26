using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Teacher.Domain.DomainObjects;

[assembly: InternalsVisibleTo("Teacher.Domain.Tests")]
namespace Teacher.Domain.CalculateAnswerOccurences
{
    class AnswerOccurenceCalculator : IAnswerOccurenceCalculator
    {
        private readonly List<AnswerOccurence> _occurences;

        public AnswerOccurenceCalculator()
        {
            _occurences = new List<AnswerOccurence>();
        }

        public IEnumerable<AnswerOccurence> GetData(IEnumerable<UserAnswer> answers)
        {
            foreach (var answer in answers)
            {
                if(!_occurences.Any(x => x.QuestionId == answer.QuestionId))
                {
                    _occurences.Add(new AnswerOccurence(answer.QuestionId, answer.AnsweredAt));
                    continue;
                }
                _occurences.Single(x => x.QuestionId == answer.QuestionId).AddOccurence(answer.AnsweredAt);
            }
            return _occurences;
        }
    }
}