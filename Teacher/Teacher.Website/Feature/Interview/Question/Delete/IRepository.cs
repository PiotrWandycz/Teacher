using System.Threading.Tasks;
using Teacher.Website.Infrastructure;

namespace Teacher.Website.Feature.Interview.Question.Delete
{
    public interface IRepository : IRepositoryMarker
    {
        Task DeleteQuestionAsync(int id);
    }
}