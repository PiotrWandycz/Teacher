using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;
using Teacher.Website.Feature.Interview.Question.Delete;

namespace Teacher.Website.Integration.Tests
{
    [TestFixture]
    public class Interview_Question_Delete_Tests : TestBase
    {
        [Test, Order(1)]
        public async Task OnGetAsync_should_work_in_a_happy_day_scenario()
        {
            var facade = GetService<IPageFacade>();
            var command = new Command
            {
                Id = 90210
            };

            var result = await facade.OnGetAsync(command);

            result.ShouldBeOfType<RedirectResult>();
            ((RedirectResult)result).Url.ShouldBe("/Interview/Question/List");
        }
    }
}