using System.Threading.Tasks;

namespace Teacher.Website.Feature.Category.List
{
    public interface IFacade
    {
        Task<Model> OnGetAsync(Query query);
    }
}