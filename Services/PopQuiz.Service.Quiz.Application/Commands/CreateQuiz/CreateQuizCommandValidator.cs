using FluentValidation;

namespace PopQuiz.Service.Quiz.Application.Commands.CreateQuiz
{
    public class CreateQuizCommandValidator : AbstractValidator<CreateQuizCommand>
    {
        public CreateQuizCommandValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(2)
                .MaximumLength(50)
                .Matches(@"(^[a-zA-Z0-9#$()!.\-+=,& ]*$)");

            RuleFor(x => x.Description).MaximumLength(500);
        }
    }
}
