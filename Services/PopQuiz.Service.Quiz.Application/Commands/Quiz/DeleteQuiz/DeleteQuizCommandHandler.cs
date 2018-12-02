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

        public Task<Unit> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
        {
            return Task<Unit>.Factory.StartNew(() =>
           {
               ProctoredQuiz quiz = dbContext.Quizes.FirstOrDefault(q => q.Id == request.QuizId);

               if (quiz == null)
               {
                   throw new EntityNotFoundException($"Quiz {request.QuizId} was not found.");
               }

               dbContext.Quizes.Remove(quiz);
               dbContext.SaveChanges();

               return Unit.Value;
           });
        }
    }
}
