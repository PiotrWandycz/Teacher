﻿using FakeItEasy;
using MediatR;
using NUnit.Framework;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Teacher.Website.Feature.Question.Create;
using Teacher.Website.Feature.Tests.Infrastructure;

namespace Teacher.Website.Feature.Tests.Question
{
    [TestFixture]
    public class Question_Create_Tests : TestBase
    {
        [Test]
        public async Task QueryHandler_should_return_a_new_model()
        {
            var query = new Query();
            var repo = A.Fake<IRepository>();
            var handler = new QueryHandler(repo);

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldNotBeNull();
        }

        [Test]
        public async Task CommandHandler_should_create_a_new_question()
        {
            var command = new Command
            {
                Question = new ViewModel.QuestionViewModel { Content = "Que", CategoryId = 3 }
            };
            var repo = A.Fake<IRepository>();
            var handler = new CommandHandler(repo);

            var result = await handler.Handle(command, CancellationToken.None);

            A.CallTo(() => repo.CreateQuestionAsync(command.Question)).MustHaveHappenedOnceExactly();
            result.ShouldBe(Unit.Value);
        }
    }
}