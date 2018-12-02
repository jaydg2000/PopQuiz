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
                .MinimumLength(RuleConstants.QUESTION_NAME_MINIMUM_LENGTH)
                .MaximumLength(RuleConstants.QUESTION_NAME_MAXIMUM_LENGTH)
                .Matches(RuleConstants.QUESTION_NAME_REGEX);
        }
    }
}
