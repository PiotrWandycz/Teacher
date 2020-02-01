using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Teacher.Website.Feature.Interview.Question.List;
using Teacher.Website.Feature.Tests.Infrastructure;

namespace Teacher.Website.Feature.Tests.Question
{
    [TestFixture]
    public class Question_List_Tests : TestBase
    {
        [Test]
        public async Task QueryHandler_should_return_a_new_model_when_query_doesnt_find_any_questions()
        {
            var query = new Query();
            var repo = A.Fake<IRepository>();
            var handler = new QueryHandler(repo);

            var result = await handler.Handle(query, CancellationToken.None);

            A.CallTo(() => repo.GetQuestionsAsync()).MustHaveHappenedOnceExactly();
            result.Questions.ShouldNotBeNull();
            result.Questions.ShouldBeEmpty();
        }

        [Test]
        public async Task QueryHandler_should_return_category_list()
        {
            var query = new Query();
            var repo = A.Fake<IRepository>();
            A.CallTo(() => repo.GetQuestionsAsync()).Returns(new List<vw_QuestionDetails>
            {
                new vw_QuestionDetails { QuestionId = 101, CategoryId = 10, CategoryName = "Cat1", Content = "Que1", Answer = "Ans1" },
                new vw_QuestionDetails { QuestionId = 102, CategoryId = 10, CategoryName = "Cat1", Content = "Que2", Answer = "Ans2" },
                new vw_QuestionDetails { QuestionId = 103, CategoryId = 11, CategoryName = "Cat2", Content = "Que3", Answer = null }
            });
            var handler = new QueryHandler(repo);

            var result = await handler.Handle(query, CancellationToken.None);

            A.CallTo(() => repo.GetQuestionsAsync()).MustHaveHappenedOnceExactly();
            result.Questions.ToList().Count.ShouldBe(3);
            result.Questions.Where(x => x.HasMissingAnswer).ToList().Count.ShouldBe(1);
        }
    }
}
