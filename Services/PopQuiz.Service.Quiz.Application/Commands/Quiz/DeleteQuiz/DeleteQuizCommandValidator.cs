﻿using FluentValidation;

namespace PopQuiz.Service.Quiz.Application.Commands.DeleteQuiz
{
    public class DeleteQuizCommandValidator : AbstractValidator<DeleteQuizCommand>
    {
        public DeleteQuizCommandValidator()
        {
            RuleFor(r => r.QuizId)                
                .GreaterThanOrEqualTo(0);
        }
    }
}
