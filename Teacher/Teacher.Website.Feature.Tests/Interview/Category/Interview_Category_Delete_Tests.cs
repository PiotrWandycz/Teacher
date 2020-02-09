using FakeItEasy;
using MediatR;
using NUnit.Framework;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Teacher.Website.Feature.Interview.Category.Delete;
using Teacher.Website.Feature.Tests.Infrastructure;

namespace Teacher.Website.Feature.Tests.Interview.Category
{
    [TestFixture]
    public class Interview_Category_Delete_Tests : TestBase
    {
        [Test]
        public async Task CommandHandler_should_delete_existing_category()
        {
            var command = new Command
            {
                Id = 23
            };
            var repo = A.Fake<IRepository>();
            var handler = new CommandHandler(repo);

            var result = await handler.Handle(command, CancellationToken.None);

            A.CallTo(() => repo.DeleteCategoryAsync(23)).MustHaveHappenedOnceExactly();
            result.ShouldBe(Unit.Value);
        }
    }
}
