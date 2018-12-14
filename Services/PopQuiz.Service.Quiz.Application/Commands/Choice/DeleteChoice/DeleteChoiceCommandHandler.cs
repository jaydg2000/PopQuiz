using MediatR;
using PopQuiz.Service.Quiz.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using PopQuiz.Service.Quiz.Domain.Entities;
using PopQuiz.Service.Common.Exceptions;

namespace PopQuiz.Service.Quiz.Application.Commands.Choice.DeleteChoice
{
    internal class DeleteChoiceCommandHandler : IRequestHandler<DeleteChoiceCommand, Unit>
    {
        private readonly QuizDbContext _dbContext;

        public DeleteChoiceCommandHandler(QuizDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteChoiceCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _dbContext.FindQuizAsync(request.QuizId, cancellationToken);
            quiz.RemoveChoiceFromQuestion(request.QuestionId, request.ChoiceId);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
