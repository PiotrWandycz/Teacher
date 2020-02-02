using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;
using Teacher.Website.Feature.Interview.Category.Create;

namespace Teacher.Website.Integration.Tests
{
    [TestFixture]
    public class Interview_Category_Create_Tests : TestBase
    {
        [Test]
        public async Task OnPostAsync_should_work_in_a_happy_day_scenario()
        {
            var facade = GetService<IPageFacade>();
            var command = new Command
            {
                Category = new ViewModel.CategoryViewModel { Name = "Cat 4" }
            };

            var result = await facade.OnPostAsync(command);

            result.ShouldBeOfType<RedirectResult>();
            ((RedirectResult)result).Url.ShouldBe("/Interview/Category/List");
        }
    }
}