using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Teacher.Website.Feature.Interview.Category.List;
using Teacher.Website.Feature.Tests.Infrastructure;

namespace Teacher.Website.Feature.Tests.Interview.Category
{
    [TestFixture]
    public class Interview_Category_List_Tests : TestBase
    {
        [Test]
        public async Task QueryHandler_should_return_a_new_model_when_query_doesnt_find_any_categories()
        {
            var query = new Query();
            var repo = A.Fake<IRepository>();
            var handler = new QueryHandler(repo);

            var result = await handler.Handle(query, CancellationToken.None);

            A.CallTo(() => repo.GetCategoriesAsync()).MustHaveHappenedOnceExactly();
            result.Categories.ShouldNotBeNull();
            result.Categories.ShouldBeEmpty();
        }

        [Test]
        public async Task QueryHandler_should_return_category_list()
        {
            var query = new Query();
            var repo = A.Fake<IRepository>();
            A.CallTo(() => repo.GetCategoriesAsync()).Returns(new List<ViewModel.CategoryViewModel>
            {
                new ViewModel.CategoryViewModel { Id = 5, Name = "Cat1" },
                new ViewModel.CategoryViewModel { Id = 6, Name = "Cat2" }
            });
            var handler = new QueryHandler(repo);

            var result = await handler.Handle(query, CancellationToken.None);

            A.CallTo(() => repo.GetCategoriesAsync()).MustHaveHappenedOnceExactly();
            result.Categories.ToList().Count.ShouldBe(2);
        }
    }
}