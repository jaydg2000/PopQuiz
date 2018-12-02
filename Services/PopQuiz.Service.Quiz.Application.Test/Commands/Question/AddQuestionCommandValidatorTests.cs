using FluentValidation.TestHelper;
using PopQuiz.Service.Quiz.Application.Commands.AddQuestion;
using PopQuiz.Service.Quiz.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PopQuiz.Service.Quiz.Application.Test.Commands.Question
{
    public class AddQuestionCommandValidatorTests
    {
        private AddQuestionCommandValidator validator;

        public AddQuestionCommandValidatorTests()
        {
            validator = new AddQuestionCommandValidator();
        }

        [Theory]
        [InlineData("Valid Question Text")]
        [InlineData("#$()!.-+=,&")]
        public void Validate_ValidText_DoesNotFail(string value)
        {
            validator.ShouldNotHaveValidationErrorFor(e => e.Text, value);
        }

        [Theory]
        [InlineData("")]
        [InlineData("Short")]
        [InlineData(@"~@%^*()[]_/\'")]
        public void Validate_InvalidText_Fails(string value)
        {
            validator.ShouldHaveValidationErrorFor(e => e.Text, value);
        }

        [Fact]
        public void Validate_MissingChoices_Fails()
        {
            validator.ShouldHaveValidationErrorFor(e => e.Answers, new List<AddedChoice>());
        }

        [Fact]
        public void Validate_SingleChoice_Fails()
        {
            validator.ShouldHaveValidationErrorFor(e => e.Answers, new List<AddedChoice>(new AddedChoice[] { new AddedChoice() }));
        }

        [Fact]
        public void Validate_NoCorrectChoice_Fails()
        {
            validator.ShouldHaveValidationErrorFor(
                e => e.Answers, 
                new List<AddedChoice>(
                    new AddedChoice[] {
                        new AddedChoice() { IsCorrect = false },
                        new AddedChoice() { IsCorrect = false }
                    }));
        }

        [Fact]
        public void Validate_WithCorrectChoice_DoesNotFail()
        {
            validator.ShouldNotHaveValidationErrorFor(
                e => e.Answers,
                new List<AddedChoice>(
                    new AddedChoice[] {
                        new AddedChoice() { IsCorrect = true },
                        new AddedChoice() { IsCorrect = false }
                    }));
        }


    }
}
