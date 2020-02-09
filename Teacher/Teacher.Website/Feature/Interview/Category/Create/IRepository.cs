using System.Threading.Tasks;
using Teacher.Website.Infrastructure;

namespace Teacher.Website.Feature.Interview.Category.Create
{
    public interface IRepository : IRepositoryMarker
    {
        Task CreateCategoryAsync(string name);
    }
}