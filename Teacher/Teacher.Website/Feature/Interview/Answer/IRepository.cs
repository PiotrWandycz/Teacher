using System.Collections.Generic;
using System.Threading.Tasks;
using Teacher.Website.Infrastructure;

namespace Teacher.Website.Feature.Interview.Answer
{
    public interface IRepository : IRepositoryMarker
    {
        Task<IEnumerable<int>> GetQuestionIdsThatHasAnswerAsync();
        Task<vw_QuestionDetails> GetQuestionAsync(int questionId);
        Task<IEnumerable<AnswerReadModel>> GetAnswersAsync(int userId);
        Task CreateAnswerAsync(Command command);
    }
}