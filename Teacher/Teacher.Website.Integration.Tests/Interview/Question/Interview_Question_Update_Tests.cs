using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;
using Teacher.Website.Feature.Interview.Question.Update;

namespace Teacher.Website.Integration.Tests
{
    [TestFixture]
    public class Interview_Question_Update_Tests : TestBase
    {
        [Test, Order(1)]
        public async Task OnGetAsync_should_work_in_a_happy_day_scenario()
        {
            var facade = GetService<IPageFacade>();
            var query = new Query() { Id = 201 };

            var result = await facade.OnGetAsync(query);

            result.Question.Content.ShouldBe("Que 1");
        }

        [Test, Order(2)]
        public async Task OnPostAsync_should_work_in_a_happy_day_scenario()
        {
            var facade = GetService<IPageFacade>();
            var command = new Command
            {
                Question = new ViewModel.QuestionInputModel { Id = 201, CategoryId = 101, Content = "Que 9" }
            };

            var result = await facade.OnPostAsync(command);

            result.ShouldBeOfType<RedirectResult>();
            ((RedirectResult)result).Url.ShouldBe("/Interview/Question/List");
        }
    }
}