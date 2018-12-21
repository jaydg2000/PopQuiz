using FluentValidation.TestHelper;
using PopQuiz.Service.Quiz.Application.Commands.Quiz.UpdateQuiz;
using Xunit;

namespace PopQuiz.Service.Quiz.Application.Test.Commands
{
    public class UpdateQuizCommandValidatorTests
    {
        private UpdateQuizCommandValidator validator;

        public UpdateQuizCommandValidatorTests()
        {
            validator = new UpdateQuizCommandValidator();
        }

        [Theory]
        [InlineData("AB")]
        [InlineData("Valid Name")]
        [InlineData("#$()!.-+=,&")]
        public void Validate_ValidName_DoesNotFail(string value)
        {
            validator.ShouldNotHaveValidationErrorFor(e => e.Name, value);
        }

        [Theory]
        [InlineData("")]
        [InlineData("A")]
        [InlineData(@"~@%^*()[]_/\'")]
        [InlineData("123456789012345678901234567890123456789012345678901234567890")]
        public void Validate_InvalidName_Fails(string value)
        {
            validator.ShouldHaveValidationErrorFor(e => e.Name, value);
        }

        [Theory]
        [InlineData("")]
        [InlineData("This is a description.")]
        public void Validate_ValidDescription_DoesNotFail(string value)
        {
            validator.ShouldNotHaveValidationErrorFor(e => e.Description, value);
        }
    }
}
