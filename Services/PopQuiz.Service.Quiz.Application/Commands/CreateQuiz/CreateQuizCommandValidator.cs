using FluentValidation;
using PopQuiz.Service.Quiz.Application.Common.Validation;

namespace PopQuiz.Service.Quiz.Application.Commands.CreateQuiz
{
    public class CreateQuizCommandValidator : AbstractValidator<CreateQuizCommand>
    {
        public CreateQuizCommandValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(RuleConstants.QUIZ_NAME_MINIMUM_LENGTH)
                .MaximumLength(RuleConstants.QUIZ_NAME_MAXIMUM_LENGTH)
                .Matches(RuleConstants.QUIZ_NAME_REGEX);

            RuleFor(x => x.Description).MaximumLength(RuleConstants.QUIZ_DESCRIPTION_MAXIMUM_LENGTH);
        }
    }
}
