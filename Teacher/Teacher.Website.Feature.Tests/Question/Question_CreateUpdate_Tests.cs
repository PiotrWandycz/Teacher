using FakeItEasy;
using MediatR;
using NUnit.Framework;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Teacher.Website.Feature.Question.CreateUpdate;
using Teacher.Website.Feature.Tests.Infrastructure;

namespace Teacher.Website.Feature.Tests.Question
{
    [TestFixture]
    public class Question_CreateUpdate_Tests : TestBase
    {
        [Test]
        public async Task QueryHandler_should_return_a_new_model_when_query_doesnt_have_question_id_set()
        {
            var query = new Query();
            var repo = A.Fake<IRepository>();
            var handler = new QueryHandler(repo);

            var result = await handler.Handle(query, CancellationToken.None);

            A.CallTo(() => repo.GetQuestionAsync(0)).MustNotHaveHappened();
            result.Question.Id.ShouldBe(0);
        }

        [Test]
        public async Task QueryHandler_should_return_a_question()
        {
            var query = new Query() { Id = 7 };
            var repo = A.Fake<IRepository>();
            A.CallTo(() => repo.GetQuestionAsync(7)).Returns(new ViewModel.QuestionViewModel() { Id = 7, Content = "Que" });
            var handler = new QueryHandler(repo);

            var result = await handler.Handle(query, CancellationToken.None);

            A.CallTo(() => repo.GetQuestionAsync(7)).MustHaveHappenedOnceExactly();
            result.Question.Id.ShouldBe(7);
            result.Question.Content.ShouldBe("Que");
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

        [Test]
        public async Task CommandHandler_should_update_existing_question()
        {
            var command = new Command
            {
                Question = new ViewModel.QuestionViewModel { Id = 11, Content = "Que", CategoryId = 5 }
            };
            var repo = A.Fake<IRepository>();
            var handler = new CommandHandler(repo);

            var result = await handler.Handle(command, CancellationToken.None);

            A.CallTo(() => repo.UpdateQuestionAsync(command.Question)).MustHaveHappenedOnceExactly();
            result.ShouldBe(Unit.Value);
        }
    }
}