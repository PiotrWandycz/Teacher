using System.Collections.Generic;
using System.Threading.Tasks;
using Teacher.Website.Infrastructure;

namespace Teacher.Website.Feature.Interview.Question.Create
{
    public interface IRepository : IRepositoryMarker
    {
        Task<IEnumerable<ViewModel.CategoryReadModel>> GetCategoriesAsync();
        Task CreateQuestionAsync(ViewModel.QuestionInputModel question);
    }
}