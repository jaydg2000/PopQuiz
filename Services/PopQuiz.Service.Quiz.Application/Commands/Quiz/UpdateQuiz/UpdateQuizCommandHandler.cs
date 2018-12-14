using MediatR;
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
            var quiz = await _dbContext.FindQuizAsync(request.QuizId, cancellationToken);
            Ensure(quiz, request.QuizId);

            quiz.Name = request.NewName;
            quiz.Description = request.NewDescription;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private void Ensure(ProctoredQuiz quiz, int quizId)
        {
            if (quiz == null)
            {
                throw new EntityNotFoundException($"Quiz {quizId} was not found.");
            }
        }
    }
}
