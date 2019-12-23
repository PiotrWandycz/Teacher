using System.Collections.Generic;
using System.Threading.Tasks;
using Teacher.Website.Infrastructure;

namespace Teacher.Website.Feature.Question.CreateUpdate
{
    public interface IRepository : IRepositoryMarker
    {
        Task<IEnumerable<ViewModel.CategoryViewModel>> GetCategoriesAsync();
        Task<ViewModel.QuestionViewModel> GetQuestionAsync(int questionId);
        Task CreateQuestionAsync(ViewModel.QuestionViewModel question);
        Task UpdateQuestionAsync(ViewModel.QuestionViewModel question);
    }
}