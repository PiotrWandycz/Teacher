using System.Threading.Tasks;
using Teacher.Website.Infrastructure;

namespace Teacher.Website.Feature.Interview.Category.Delete
{
    public interface IRepository : IRepositoryMarker
    {
        Task DeleteCategoryAsync(int id);
    }
}