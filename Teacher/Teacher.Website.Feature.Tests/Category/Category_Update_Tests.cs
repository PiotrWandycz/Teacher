using FakeItEasy;
using MediatR;
using NUnit.Framework;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Teacher.Website.Feature.Interview.Category.Update;
using Teacher.Website.Feature.Tests.Infrastructure;

namespace Teacher.Website.Feature.Tests.Category
{
    [TestFixture]
    public class Category_Update_Tests : TestBase
    {
        [Test]
        public async Task QueryHandler_should_return_a_category()
        {
            var query = new Query() { Id = 1 };
            var repo = A.Fake<IRepository>();
            A.CallTo(() => repo.GetCategoryAsync(1)).Returns(new ViewModel.CategoryViewModel() { Id = 1, Name = "Cat" });
            var handler = new QueryHandler(repo);

            var result = await handler.Handle(query, CancellationToken.None);

            A.CallTo(() => repo.GetCategoryAsync(1)).MustHaveHappenedOnceExactly();
            result.Category.Id.ShouldBe(1);
            result.Category.Name.ShouldBe("Cat");
        }

        [Test]
        public async Task CommandHandler_should_update_existing_category()
        {
            var command = new Command
            {
                Category = new ViewModel.CategoryViewModel { Id = 5, Name = "Cat" }
            };
            var repo = A.Fake<IRepository>();
            var handler = new CommandHandler(repo);

            var result = await handler.Handle(command, CancellationToken.None);

            A.CallTo(() => repo.UpdateCategoryAsync(5, "Cat")).MustHaveHappenedOnceExactly();
            result.ShouldBe(Unit.Value);
        }
    }
}