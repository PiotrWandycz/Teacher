using System.Collections.Generic;
using System.Threading.Tasks;
using Teacher.Website.Infrastructure;

namespace Teacher.Website.Feature.Interview.Category.List
{
    public interface IRepository : IRepositoryMarker
    {
        Task<IEnumerable<ViewModel.CategoryInputModel>> GetCategoriesAsync();
    }
}