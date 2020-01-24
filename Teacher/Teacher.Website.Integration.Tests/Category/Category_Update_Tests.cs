﻿using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;
using Teacher.Website.Feature.Category.Update;

namespace Teacher.Website.Integration.Tests
{
    [TestFixture]
    public class Category_Update_Tests : TestBase
    {
        [Test]
        public async Task OnGetAsync_should_work_in_a_happy_day_scenario()
        {
            var facade = GetService<IPageFacade>();
            var query = new Query() { Id = 101 };

            var result = await facade.OnGetAsync(query);

            result.Category.Name.ShouldBe("Cat 1");
        }

        [Test]
        public async Task OnPostAsync_should_work_in_a_happy_day_scenario()
        {
            var facade = GetService<IPageFacade>();
            var command = new Command
            {
                Category = new ViewModel.CategoryViewModel { Id = 102, Name = "Cat 5" }
            };

            var result = await facade.OnPostAsync(command);

            result.ShouldBeOfType<RedirectResult>();
            ((RedirectResult)result).Url.ShouldBe("/Category/List");
        }
    }
}