using System.Threading.Tasks;

namespace Teacher.Website.Feature.Question.List
{
    public interface IFacade
    {
        Task<Model> OnGetAsync(Query query);
    }
}