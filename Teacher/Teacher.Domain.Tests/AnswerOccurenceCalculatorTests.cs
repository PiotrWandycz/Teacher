using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Teacher.Domain.CalculateAnswerOccurences;
using Teacher.Domain.DomainObjects;

namespace Teacher.Domain.Tests
{
    [TestFixture]

    public class AnswerOccurenceCalculatorTests
    {
        [Test]
        public void AnswerOccurenceCalculator_should_work_in_a_happy_day_scenario()
        {
            // Arrange
            var service = new AnswerOccurenceCalculator();
            var answers = GetAnswers();

            // Act
            var result = service.GetData(answers);

            // Assert
            result.ToList().Count.ShouldBe(4);
            result.Single(x => x.QuestionId == 1).AnsweredTimes.ShouldBe(3);
            result.Single(x => x.QuestionId == 4).AnsweredDates.ShouldBe(new List<DateTime> { new DateTime(2020, 01, 29) });
        }

        private List<UserAnswer> GetAnswers()
        {
            return new List<UserAnswer>
            {
                new UserAnswer(1, new DateTime(2020,01,25)),
                new UserAnswer(1, new DateTime(2020,01,26)),
                new UserAnswer(1, new DateTime(2020,01,29)),
                new UserAnswer(2, new DateTime(2020,01,26)),
                new UserAnswer(2, new DateTime(2020,02,29)),
                new UserAnswer(3, new DateTime(2020,01,27)),
                new UserAnswer(3, new DateTime(2020,02,29)),
                new UserAnswer(4, new DateTime(2020,01,29)),
            };
        }
    }
}