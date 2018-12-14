using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PopQuiz.Service.Common.Domain.Infrastructure;
using PopQuiz.Service.Common.Exceptions;
using PopQuiz.Service.Quiz.Application.Commands.UpdateChoice;
using PopQuiz.Service.Quiz.Persistence;
using PopQuiz.Service.Quiz.Domain.Entities;

namespace PopQuiz.Service.Quiz.Application.Commands.UpdateChoice
{
    public class UpdateChoiceCommandHandler : IRequestHandler<UpdateChoiceCommand,Unit>
    {
        private readonly QuizDbContext _dbContext;

        public UpdateChoiceCommandHandler(QuizDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateChoiceCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _dbContext.FindQuizAsync(request.QuizId, cancellationToken);
            quiz.UpdateChoiceInQuestion(request.QuestionId, request.ChoiceId, request.Text, request.IsCorrect);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private static void Ensure(Domain.Entities.Choice choice, int choiceId)
        {
            if (choice == null)
            {
                throw new EntityNotFoundException("Choice", choiceId);
            }
        }

    }
}
