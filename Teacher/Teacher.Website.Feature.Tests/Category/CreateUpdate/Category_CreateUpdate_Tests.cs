using FakeItEasy;
using MediatR;
using NUnit.Framework;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Teacher.Website.Feature.Tests.Infrastructure;

namespace Teacher.Website.Feature.Category.CreateUpdate
{
    [TestFixture]
    public class Category_CreateUpdate_Tests : TestBase
    {
        [Test]
        public async Task QueryHandler_should_return_a_new_model_when_query_doesnt_have_category_id_set()
        {
            var query = new Query();
            var repo = A.Fake<IRepository>();
            var handler = new QueryHandler(repo);

            var result = await handler.Handle(query, CancellationToken.None);

            A.CallTo(() => repo.GetCategoryAsync(0)).MustNotHaveHappened();
            result.Category.Id.ShouldBe(0);
            result.Category.Name.ShouldBe(string.Empty);
        }

        [Test]
        public async Task QueryHandler_should_return_a_category()
        {
            var query = new Query() { CategoryId = 1 };
            var repo = A.Fake<IRepository>();
            A.CallTo(() => repo.GetCategoryAsync(1)).Returns(new Model.CategoryModel() { Id = 1, Name = "Cat" });
            var handler = new QueryHandler(repo);

            var result = await handler.Handle(query, CancellationToken.None);

            A.CallTo(() => repo.GetCategoryAsync(1)).MustHaveHappenedOnceExactly();
            result.Category.Id.ShouldBe(1);
            result.Category.Name.ShouldBe("Cat");
        }

        [Test]
        public async Task CommandHandler_should_create_a_new_category()
        {
            var command = new Command
            {
                Category = new Model.CategoryModel { Name = "Cat" }
            };
            var repo = A.Fake<IRepository>();
            var handler = new CommandHandler(repo);

            var result = await handler.Handle(command, CancellationToken.None);

            A.CallTo(() => repo.CreateCategoryAsync("Cat")).MustHaveHappenedOnceExactly();
            result.ShouldBe(Unit.Value);
        }

        [Test]
        public async Task CommandHandler_should_update_existing_category_name()
        {
            var command = new Command
            {
                Category = new Model.CategoryModel { Id = 5, Name = "Cat" }
            };
            var repo = A.Fake<IRepository>();
            var handler = new CommandHandler(repo);

            var result = await handler.Handle(command, CancellationToken.None);

            A.CallTo(() => repo.UpdateCategoryAsync(5, "Cat")).MustHaveHappenedOnceExactly();
            result.ShouldBe(Unit.Value);
        }
    }
}