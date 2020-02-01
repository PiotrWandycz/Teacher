using NUnit.Framework;
using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Teacher.Website.Feature.Interview.Category.List;

namespace Teacher.Website.Integration.Tests
{
    [TestFixture]
    public class Category_List_Tests : TestBase
    {
        [Test]
        public async Task OnGetAsync_should_work_in_a_happy_day_scenario()
        {
            var facade = GetService<IPageFacade>();
            var query = new Query();

            var result = await facade.OnGetAsync(query);

            result.Categories.ToList().Count.ShouldBeGreaterThan(1);
        }
    }
}