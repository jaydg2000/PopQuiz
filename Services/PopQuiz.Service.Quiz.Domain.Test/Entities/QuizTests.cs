using System;
using System.Collections.Generic;
using PopQuiz.Service.Quiz.Domain.Entities;
using System.Linq;
using Xunit;

namespace PopQuiz.Service.Quiz.Domain.Test.Entities
{
    public class QuizTests
    {
        private Domain.Entities.Quiz target;
        private int id = 1;
        private string name = "Name";
        private string description = "Description";

        public QuizTests()
        {
            target = new Domain.Entities.Quiz(id, name, description);
        }

        [Fact]
        public void ctor_builds_quiz()
        {
            Assert.Equal(id, target.Id);
            Assert.Equal(name, target.Name);
            Assert.Equal(description, target.Description);
        }

        [Fact]
        public void AddQuestion_WithANewQuestion_AddsQuestionToQuiz()
        {
            const string name = "New Quiz";
            var choices = new List<Tuple<string, bool>>();

            target.AddQuestion(name, choices);
            Question actual = target.Questions.FirstOrDefault();

            Assert.NotNull(actual);            
        }
    }
}
