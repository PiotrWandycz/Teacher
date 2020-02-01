using System.Collections.Generic;
using System.Threading.Tasks;
using Teacher.Website.Infrastructure;

namespace Teacher.Website.Feature.Interview.Question.List
{
    public interface IRepository : IRepositoryMarker
    {
        Task<IEnumerable<vw_QuestionDetails>> GetQuestionsAsync();
    }
}