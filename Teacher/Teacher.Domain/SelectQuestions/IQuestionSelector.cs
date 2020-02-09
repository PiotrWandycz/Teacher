using System.Collections.Generic;
using Teacher.Domain.DomainObjects;
using Teacher.Domain.Infrastructure;

namespace Teacher.Domain.SelectQuestions
{
    public interface IQuestionSelector : IDomainService
    {
        int GetNextQuestionId(IEnumerable<int> questionIds, IEnumerable<AnswerOccurence> occurences);
    }
}