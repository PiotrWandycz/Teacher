using System.Collections.Generic;
using System.Threading.Tasks;
using Teacher.Website.Infrastructure;

namespace Teacher.Website.Feature.Interview.Question.Update
{
    public interface IRepository : IRepositoryMarker
    {
        Task<IEnumerable<ViewModel.CategoryReadModel>> GetCategoriesAsync();
        Task<ViewModel.QuestionInputModel> GetQuestionAsync(int questionId);
        Task UpdateQuestionAsync(ViewModel.QuestionInputModel question);
    }
}