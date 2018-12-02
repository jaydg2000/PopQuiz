using FluentValidation;
using PopQuiz.Service.Quiz.Application.Common.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Application.Commands.UpdateQuestion
{
    public class UpdateQuestionCommandValidator : AbstractValidator<UpdateQuestionCommand>
    {
        public UpdateQuestionCommandValidator()
        {
            RuleFor(q => q.NewText)
                .MinimumLength(RuleConstants.QUESTION_TEXT_MINIMUM_LENGTH)
                .MaximumLength(RuleConstants.QUESTION_TEXT_MAXIMUM_LENGTH)
                .Matches(RuleConstants.QUESTION_TEXT_REGEX);
        }
    }
}
