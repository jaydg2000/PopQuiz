using FluentValidation;
using PopQuiz.Service.Quiz.Application.Common.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Application.Commands.Choice.AddChoice
{
    public class AddChoiceCommandValidator : AbstractValidator<AddChoiceCommand>
    {
        public AddChoiceCommandValidator()
        {
            RuleFor(e => e.Text)
                .Length(RuleConstants.CHOICE_TEXT_MINIMUM_LENGTH, RuleConstants.CHOICE_TEXT_MAXIMUM_LENGTH)
                .Matches(RuleConstants.CHOICE_TEXT_REGEX);
        }
    }
}
