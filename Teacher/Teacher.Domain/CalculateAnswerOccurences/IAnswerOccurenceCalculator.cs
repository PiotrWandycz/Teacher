using System.Collections.Generic;
using Teacher.Domain.DomainObjects;
using Teacher.Domain.Infrastructure;

namespace Teacher.Domain.CalculateAnswerOccurences
{
    public interface IAnswerOccurenceCalculator : IDomainService
    {
        IEnumerable<AnswerOccurence> GetData(IEnumerable<UserAnswer> answers);
    }
}