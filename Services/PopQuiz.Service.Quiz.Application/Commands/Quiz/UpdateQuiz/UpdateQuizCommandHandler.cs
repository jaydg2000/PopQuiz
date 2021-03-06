﻿using MediatR;
using PopQuiz.Service.Common.Exceptions;
using PopQuiz.Service.Quiz.Domain.Entities;
using PopQuiz.Service.Quiz.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace PopQuiz.Service.Quiz.Application.Commands.UpdateQuiz
{
    public class UpdateQuizCommandHandler : IRequestHandler<UpdateQuizCommand, Unit>
    {
        private readonly QuizDbContext _dbContext;

        public UpdateQuizCommandHandler(QuizDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _dbContext.FindQuizAsync(request.Id, cancellationToken);
            Ensure(quiz, request.Id);

            quiz.Name = request.Name;
            quiz.Description = request.Description;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private void Ensure(Domain.Entities.Quiz quiz, int quizId)
        {
            if (quiz == null)
            {
                throw new EntityNotFoundException($"Quiz {quizId} was not found.");
            }
        }
    }
}
