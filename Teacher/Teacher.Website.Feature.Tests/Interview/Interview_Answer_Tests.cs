using FakeItEasy;
using MediatR;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Teacher.Domain.CalculateAnswerOccurences;
using Teacher.Domain.SelectQuestions;
using Teacher.Website.Feature.Interview.Answer;
using Teacher.Website.Feature.Tests.Infrastructure;

namespace Teacher.Website.Feature.Tests.Interview
{
    [TestFixture]
    public class Interview_Answer_Tests : TestBase
    {
        [Test]
        public async Task QueryHandler_should_return_a_question()
        {
            var query = new Query { UserId = 99 };
            var handler = CreateQueryHandler();

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldNotBeNull();
            result.Answer.ShouldNotBeNull();
            result.Answer.QuestionId.ShouldBe(10);
            result.Question.ShouldNotBeNull();
            result.Question.CategoryName.ShouldBe("cat");
        }

        private QueryHandler CreateQueryHandler()
        {
            var repo = A.Fake<IRepository>();
            A.CallTo(() => repo.GetQuestionIdsThatHasAnswerAsync()).Returns(new List<int> { 10 });
            A.CallTo(() => repo.GetAnswersAsync(99)).Returns(new List<AnswerReadModel>());
            A.CallTo(() => repo.GetQuestionAsync(10)).Returns(new vw_QuestionDetails { QuestionId = 10, Answer = "ans", CategoryId = 20, CategoryName = "cat", Content = "que?"});

            var questionSelector = GetService<IQuestionSelector>();
            var answerOccurenceCalculator = GetService<IAnswerOccurenceCalculator>();
            return new QueryHandler(repo, questionSelector, answerOccurenceCalculator);
        }

        [Test]
        public async Task CommandHandler_should_add_an_answer()
        {
            var command = new Command
            {
                QuestionId = 105,
                UserId = 75,
                WasAnswerCorrect = true
            };
            var repo = A.Fake<IRepository>();
            var handler = new CommandHandler(repo);

            var result = await handler.Handle(command, CancellationToken.None);

            A.CallTo(() => repo.CreateAnswerAsync(command)).MustHaveHappenedOnceExactly();
            result.ShouldBe(Unit.Value);
        }
    }
}