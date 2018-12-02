using FluentValidation.TestHelper;
using PopQuiz.Service.Quiz.Application.Commands.DeleteQuiz;
using Xunit;

namespace PopQuiz.Service.Quiz.Application.Test.Commands
{
    public class DeleteQuizCommandValidatorTests
    {
        private DeleteQuizCommandValidator validator;

        public DeleteQuizCommandValidatorTests()
        {
            validator = new DeleteQuizCommandValidator();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        public void Validate_ValidQuizId_DoesNotFail(int value)
        {
            validator.ShouldNotHaveValidationErrorFor(e => e.QuizId, value);
        }

        [Fact]
        public void Validate_InValidQuizId_Fails()
        {
            validator.ShouldHaveValidationErrorFor(e => e.QuizId, -1);
        }
    }
}
