using MediatR;
using PopQuiz.Service.Common.Exceptions;
using PopQuiz.Service.Quiz.Domain.Entities;
using PopQuiz.Service.Quiz.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PopQuiz.Service.Quiz.Application.Commands.DeleteQuiz
{
    public class DeleteQuizCommandHandler : IRequestHandler<DeleteQuizCommand, Unit>
    {
        private QuizDbContext dbContext;

        public DeleteQuizCommandHandler(QuizDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
        {
           ProctoredQuiz quiz = await dbContext.FindQuizAsync(request.QuizId, cancellationToken);

           if (quiz == null)
           {
               throw new EntityNotFoundException($"Quiz {request.QuizId} was not found.");
           }

           dbContext.Quizes.Remove(quiz);
           await dbContext.SaveChangesAsync(cancellationToken);

           return Unit.Value;
        }
    }
}
