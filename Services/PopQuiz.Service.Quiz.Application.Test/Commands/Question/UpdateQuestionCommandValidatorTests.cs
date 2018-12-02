using FluentValidation.TestHelper;
using PopQuiz.Service.Quiz.Application.Commands.UpdateQuestion;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PopQuiz.Service.Quiz.Application.Test.Commands.Question
{
    public class UpdateQuestionCommandValidatorTests
    {
        private UpdateQuestionCommandValidator validator;

        public UpdateQuestionCommandValidatorTests()
        {
            validator = new UpdateQuestionCommandValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData("Short")]        
        public void Validate_InvalidText_Fails(string value)
        {
            validator.ShouldHaveValidationErrorFor(e => e.NewText, value);
        }

        [Fact]
        public void Validate_TooLongText_Fails()
        {
            validator.ShouldHaveValidationErrorFor(e => e.NewText, GetLongString(2001));
        }

        private string GetLongString(int size)
        {
            StringBuilder sb = new StringBuilder(size);
            while(sb.Length < size)
            {
                sb.Append("x");
            }
            return sb.ToString();
        }
    }
}
