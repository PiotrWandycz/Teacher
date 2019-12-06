using System.Threading.Tasks;

namespace Teacher.Website.Feature.Category.CreateUpdate
{
    public interface IRepository
    {
        Task<Model.CategoryModel> GetCategoryAsync(int categoryId);
        Task CreateCategoryAsync(string name);
        Task UpdateCategoryAsync(int id, string name);
    }
}