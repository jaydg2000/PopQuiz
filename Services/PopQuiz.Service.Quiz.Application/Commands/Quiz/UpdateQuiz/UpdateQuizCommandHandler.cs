using MediatR;
using PopQuiz.Service.Quiz.Application.Exceptions;
using PopQuiz.Service.Quiz.Domain.Entities;
using PopQuiz.Service.Quiz.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PopQuiz.Service.Quiz.Application.Commands.UpdateQuiz
{
    public class UpdateQuizCommandHandler : IRequestHandler<UpdateQuizCommand, Unit>
    {
        private QuizDbContext dbContext;

        public UpdateQuizCommandHandler(QuizDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Unit> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            return Task<Unit>.Factory.StartNew( () => 
            {
                ProctoredQuiz quiz = dbContext.Quizes.FirstOrDefault(q => q.Id == request.QuizId);
                Ensure(quiz);

                ProctoredQuiz newQuiz = new ProctoredQuiz(quiz.Id, request.NewName, request.NewDescription);
                quiz = newQuiz;
                dbContext.SaveChanges();

                return Unit.Value;
            });
        }

        private void Ensure(ProctoredQuiz quiz)
        {
            if (quiz == null)
            {
                throw new EntityNotFoundException($"Quiz {quiz.Id} was not found.");
            }
        }
    }
}
