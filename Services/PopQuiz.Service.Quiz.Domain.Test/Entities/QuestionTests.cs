﻿using PopQuiz.Service.Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PopQuiz.Service.Quiz.Domain.Test.Entities
{
    public class QuestionTests
    {
        private Question target;
        private const int id = 1;
        private const string text = "What is the answer to this question?";

        public QuestionTests()
        {
            target = new Question(id, text);
        }

        [Fact]
        public void ctor_builds_question()
        {
            Assert.NotNull(target);
            Assert.Equal(id, target.Id);
            Assert.Equal(text, target.Text);
        }

        [Fact]
        public void AddChoice_NewChoice_IsAdded()
        {
            const string choiceText = "42";
            const bool choiceIsCorrect = true;

            target.AddChoice(choiceText, choiceIsCorrect);
            Choice actual = target.Choices.FirstOrDefault();

            Assert.NotNull(actual);
            Assert.Equal(choiceText, actual.Text);
            Assert.Equal(choiceIsCorrect, actual.IsCorrect);
        }

        [Fact]
        public void DeleteChoice_ExistingChoice_IsRemoved()
        {
            const string choiceText = "42";
            const bool choiceIsCorrect = true;

            target.AddChoice(choiceText, choiceIsCorrect);
            Choice addedChoice = target.Choices.FirstOrDefault();
            Assert.NotNull(addedChoice);

            target.RemoveChoice(addedChoice.Id);
            Choice actual = target.Choices.FirstOrDefault();
            Assert.Null(actual);
        }
    }
}
