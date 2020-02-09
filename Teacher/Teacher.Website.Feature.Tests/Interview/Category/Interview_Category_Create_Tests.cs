using FakeItEasy;
using MediatR;
using NUnit.Framework;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Teacher.Website.Feature.Interview.Category.Create;
using Teacher.Website.Feature.Tests.Infrastructure;

namespace Teacher.Website.Feature.Tests.Interview.Category
{
    [TestFixture]
    public class Interview_Category_Create_Tests : TestBase
    {
        [Test]
        public async Task QueryHandler_should_return_a_new_model()
        {
            var query = new Query();
            var handler = new QueryHandler();

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldNotBeNull();
        }

        [Test]
        public async Task CommandHandler_should_create_a_new_category()
        {
            var command = new Command
            {
                Category = new ViewModel.CategoryInputModel { Name = "Cat" }
            };
            var repo = A.Fake<IRepository>();
            var handler = new CommandHandler(repo);

            var result = await handler.Handle(command, CancellationToken.None);

            A.CallTo(() => repo.CreateCategoryAsync("Cat")).MustHaveHappenedOnceExactly();
            result.ShouldBe(Unit.Value);
        }
    }
}