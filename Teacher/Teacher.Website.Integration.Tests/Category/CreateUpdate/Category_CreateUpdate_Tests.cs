﻿using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;
using Teacher.Website.Feature.Category.CreateUpdate;
using Teacher.Website.Integration.Tests.Infrastructure;

namespace Teacher.Website.Integration.Tests.Category.CreateUpdate
{
    [TestFixture]
    public class Category_CreateUpdate_Tests : TestBase
    {
        [Test]
        public async Task OnGetAsync_should_work_in_a_happy_day_scenario()
        {
            var facade = GetService<IPageFacade>();
            var query = new Query() { CategoryId = 101 };

            var result = await facade.OnGetAsync(query);

            result.Category.Name.ShouldBe("Programowanie obiektowe");
        }

        [Test]
        public async Task OnPostAsync_should_work_in_a_happy_day_scenario()
        {
            var facade = GetService<IPageFacade>();
            var command = new Command
            {
                Category = new Model.CategoryModel { Name = "Bazy danych" }
            };

            var result = await facade.OnPostAsync(command);

            result.ShouldBeOfType<RedirectToPageResult>();
            ((RedirectToPageResult)result).PageName.ShouldBe("List");
        }
    }
}