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
        private QuizDbContext dbContext;
        public DeleteQuestionCommandHandler(QuizDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // TODO. How can I access the cancellation token using MediatR?
        public Task<Unit> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            return Task<Unit>.Factory.StartNew(() =>
            {
                ProctoredQuiz quiz = dbContext.FindQuizWithQuestion(request.QuestionId);
                if (quiz == null)
                {
                    throw new EntityNotFoundException("No Quiz with Question", request.QuestionId);
                }

                quiz.RemoveQuestion(request.QuestionId);
                dbContext.SaveChangesAsync();

                return Unit.Value;
            });
        }
    }
}
