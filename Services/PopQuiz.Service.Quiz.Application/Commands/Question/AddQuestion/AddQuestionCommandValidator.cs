using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PopQuiz.Service.Quiz.Application.Common.Validation;

namespace PopQuiz.Service.Quiz.Application.Commands.AddQuestion
{
    public class AddQuestionCommandValidator : AbstractValidator<AddQuestionCommand>
    {
        public AddQuestionCommandValidator()
        {
            RuleFor(q => q.Text)
                .MinimumLength(RuleConstants.QUESTION_NAME_MINIMUM_LENGTH)
                .MaximumLength(RuleConstants.QUESTION_NAME_MAXIMUM_LENGTH)
                .Matches(RuleConstants.QUESTION_NAME_REGEX);

            RuleFor(q => q.Answers)
                .Must(answers => answers.Count() >= RuleConstants.QUESTION_MINIMUM_NUMBER_OF_CHOICES)
                .WithMessage($"There must be at least {RuleConstants.QUESTION_MINIMUM_NUMBER_OF_CHOICES} choices.")
                .Must(answers => answers.Any( ans => ans.IsCorrect))
                .WithMessage("There must be at least one correct answer.");
        }
    }
}
