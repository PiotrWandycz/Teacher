using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Teacher.Domain.DomainObjects;
using Teacher.Domain.Infrastructure;

[assembly: InternalsVisibleTo("Teacher.Domain.Tests")]
namespace Teacher.Domain.SelectQuestions
{
    class QuestionSelector : IQuestionSelector
    {
        public int GetNextQuestionId(IEnumerable<int> questionIds, IEnumerable<AnswerOccurence> occurences)
        {
            if (!questionIds.Any())
                throw new DomainException("List of question ids is empty in QuestionSelector");

            if (!occurences.Any())
                return GetRandomInt(questionIds);

            var questionPool = BuildQuestionPool(questionIds, occurences);
            return GetRandomInt(questionPool);
        }

        private IEnumerable<int> BuildQuestionPool(IEnumerable<int> questionIds, IEnumerable<AnswerOccurence> occurences)
        {
            var notAnsweredQuestions = questionIds.Except(occurences.Select(x => x.QuestionId));
            var rarelyAnsweredQuestions = occurences.Where(x => x.AnsweredTimes < 3).Select(x => x.QuestionId);
            return notAnsweredQuestions.Union(rarelyAnsweredQuestions);
        }

        private int GetRandomInt(IEnumerable<int> collection)
        {
            return collection.OrderBy(x => new Random().NextDouble()).First();
        }
    }
}