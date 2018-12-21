using FluentValidation;
using PopQuiz.Service.Quiz.Application.Commands.UpdateQuiz;
using PopQuiz.Service.Quiz.Application.Common.Validation;

namespace PopQuiz.Service.Quiz.Application.Commands.Quiz.UpdateQuiz
{
    public class UpdateQuizCommandValidator : AbstractValidator<UpdateQuizCommand>
    {
        public UpdateQuizCommandValidator()
        {
            // TODO: how can I reuse these similar rules for create quiz command validation?
            RuleFor(c => c.Id)
                .GreaterThanOrEqualTo(0);

            RuleFor(c => c.Name)
                .Length(RuleConstants.QUIZ_NAME_MINIMUM_LENGTH, RuleConstants.QUIZ_NAME_MAXIMUM_LENGTH)
                .Matches(RuleConstants.QUIZ_NAME_REGEX);

            RuleFor(c => c.Description)
                .Length(
                    RuleConstants.QUIZ_DESCRIPTION_MINIMUM_LENGTH, 
                    RuleConstants.QUIZ_DESCRIPTION_MAXIMUM_LENGTH);
        }
    }
}
