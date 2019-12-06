using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Teacher.Website.Feature.Category.CreateUpdate;
using Teacher.Website.Infrastructure.Database;

namespace Teacher.Website.Feature.Tests
{
    [TestFixture]
    public class Category_CreateUpdate_Tests : TestBase
    {
        [Test]
        public async Task OnGetAsync_should_work_in_a_happy_day_scenario()
        {
            var facade = (IPageFacade)ServiceProvider.GetService(typeof(IPageFacade));
            var query = new Query() { CategoryId = 1 };

            var result = await facade.OnGetAsync(query);

            result.Category.Name.ShouldBe("Programowanie obiektowe");
        }

        [Test]
        public async Task OnPostAsync_should_work_in_a_happy_day_scenario()
        {
            var facade = (IPageFacade)ServiceProvider.GetService(typeof(IPageFacade));
            var command = new Command
            {
                Category = new Model.CategoryModel { Name = "Bazy danych" }
            };

            var result = await facade.OnPostAsync(command);

            result.ShouldBeOfType<RedirectToPageResult>();
            ((RedirectToPageResult)result).PageName.ShouldBe("List");
        }

        [Test]
        public async Task QueryHandler_should_return_a_category_from_the_database()
        {
            var config = (IConfiguration)ServiceProvider.GetService(typeof(IConfiguration));
            var query = new Query() { CategoryId = 1 };
            var handler = new QueryHandler(config);

            var result = await handler.Handle(query, CancellationToken.None);

            result.Category.Name.ShouldBe("Programowanie obiektowe");
        }

        [Test]
        public async Task QueryHandler_should_return_a_new_model_if_it_doesnt_find_category_in_the_database()
        {
            var config = (IConfiguration)ServiceProvider.GetService(typeof(IConfiguration));
            var query = new Query() { CategoryId = -1 };
            var handler = new QueryHandler(config);

            var result = await handler.Handle(query, CancellationToken.None);

            result.Category.Id.ShouldBe(0);
            result.Category.Name.ShouldBe(string.Empty);
        }

        [Test]
        public async Task CommandHandler_should_add_a_new_category_to_the_database()
        {
            var dbContext = (TeacherContext)ServiceProvider.GetService(typeof(TeacherContext));
            var command = new Command
            {
                Category = new Model.CategoryModel { Name = "Bazy danych" }
            };
            var handler = new CommandHandler(dbContext);

            var result = await handler.Handle(command, CancellationToken.None);

            result.ShouldBe(Unit.Value);
        }

        [Test]
        public async Task CommandHandler_should_update_existing_category_name_in_the_database()
        {
            Assert.Fail();
        }
    }
}