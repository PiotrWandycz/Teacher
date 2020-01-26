using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Teacher.Domain.DomainObjects;
using Teacher.Domain.SelectQuestions;

namespace Teacher.Domain.Tests
{
    [TestFixture]

    public class QuestionSelectorTests
    {
        [Test]
        [Repeat(25)]
        public void QuestionSelector_should_work_in_a_happy_day_scenario()
        {
            // Arrange
            var service = new QuestionSelector();
            var questionIds = GetQuestionIds();
            var occurences = GetOccurences();

            // Act
            var result = service.GetNextQuestionId(questionIds, occurences);

            // Assert
            result.ShouldNotBe(1);
            result.ShouldBeInRange(2, 8);
        }

        private List<int> GetQuestionIds()
        {
            return new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
        }

        private List<AnswerOccurence> GetOccurences()
        {
            var occurences = new List<AnswerOccurence>();
            var occurence = new AnswerOccurence(1, new DateTime(2020, 01, 25));
            occurence.AddOccurence(new DateTime(2020, 01, 26));
            occurence.AddOccurence(new DateTime(2020, 01, 27));
            occurences.Add(occurence);

            occurence = new AnswerOccurence(2, new DateTime(2020, 02, 25));
            occurence.AddOccurence(new DateTime(2020, 02, 26));
            occurences.Add(occurence);
            
            occurence = new AnswerOccurence(3, new DateTime(2020, 02, 25));
            occurence.AddOccurence(new DateTime(2020, 02, 26));
            occurences.Add(occurence);
           
            occurence = new AnswerOccurence(4, new DateTime(2020, 02, 25));
            occurence.AddOccurence(new DateTime(2020, 02, 26));
            occurences.Add(occurence);
          
            return occurences;
        }
    }
}