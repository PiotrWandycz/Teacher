using NUnit.Framework;
using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Teacher.Website.Feature.Interview.Question.List;

namespace Teacher.Website.Integration.Tests
{
    [TestFixture]
    public class Interview_Question_List_Tests : TestBase
    {
        [Test]
        public async Task OnGetAsync_should_work_in_a_happy_day_scenario()
        {
            var facade = GetService<IPageFacade>();
            var query = new Query();

            var result = await facade.OnGetAsync(query);

            result.Questions.ToList().Count.ShouldBeGreaterThan(2);
            result.Questions.Single(x => x.Id == 203).HasMissingAnswer.ShouldBeFalse();
            result.Questions.Single(x => x.Id == 204).HasMissingAnswer.ShouldBeTrue();
        }
    }
}