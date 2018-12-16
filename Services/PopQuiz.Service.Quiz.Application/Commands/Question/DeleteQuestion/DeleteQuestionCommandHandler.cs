using MediatR;
using Microsoft.EntityFrameworkCore;
using PopQuiz.Service.Common.Exceptions;
using PopQuiz.Service.Quiz.Domain.Entities;
using PopQuiz.Service.Quiz.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PopQuiz.Service.Quiz.Application.Commands.DeleteQuestion
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand>
    {
        private readonly QuizDbContext _dbContext;
        public DeleteQuestionCommandHandler(QuizDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quiz quiz = await _dbContext.FindQuizAsync(request.QuizId, cancellationToken);
            if (quiz == null)
            {
                throw new EntityNotFoundException("No Quiz with Question", request.QuestionId);
            }

            quiz.RemoveQuestion(request.QuestionId);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
