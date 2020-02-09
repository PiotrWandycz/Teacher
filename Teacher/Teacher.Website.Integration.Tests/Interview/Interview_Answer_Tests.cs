using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;
using Teacher.Website.Feature.Interview.Answer;

namespace Teacher.Website.Integration.Tests
{
    [TestFixture]
    public class Interview_Answer_Tests : TestBase
    {
        [Test, Order(3)]
        public async Task OnGetAsync_should_work_in_a_happy_day_scenario()
        {
            var facade = GetService<IPageFacade>();
            var query = new Query() { UserId = 50 };

            var result = await facade.OnGetAsync(query);

            result.ShouldNotBeNull();
            result.Answer.ShouldNotBeNull();
            result.Question.ShouldNotBeNull();
            result.Question.Id.ShouldBeInRange(201, 204);
        }

        [Test, Order(4)]
        public async Task OnPostAsync_should_work_in_a_happy_day_scenario()
        {
            var facade = GetService<IPageFacade>();
            var command = new Command
            {
                UserId = 50,
                QuestionId = 201,
                WasAnswerCorrect = true
            };

            var result = await facade.OnPostAsync(command);

            result.ShouldBeOfType<RedirectResult>();
            ((RedirectResult)result).Url.ShouldBe("/Interview/Answer");
        }
    }
}