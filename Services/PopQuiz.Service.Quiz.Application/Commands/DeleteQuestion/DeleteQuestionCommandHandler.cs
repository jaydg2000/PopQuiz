using MediatR;
using Microsoft.EntityFrameworkCore;
using PopQuiz.Service.Quiz.Application.Exceptions;
using PopQuiz.Service.Quiz.Domain.Entities;
using PopQuiz.Service.Quiz.Persistence;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace PopQuiz.Service.Quiz.Application.Commands.DeleteQuestion
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand>
    {
        private QuizDbContext dbContext; 
        public DeleteQuestionCommandHandler(QuizDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Unit> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            return Task<Unit>.Factory.StartNew(() =>
           {
               ProctoredQuiz quiz = dbContext.Quizes
                    .Where(q => q.Id == request.QuizId)
                    .Include( q => q.Questions)
                    .ThenInclude( qe => qe.Choices)
                    .FirstOrDefault();
                                    

               if (quiz == null)
               {
                   throw new EntityNotFoundException($"Quiz {request.QuizId} was not found.");
               }

               var questionToRemove = quiz.Questions.FirstOrDefault(q => q.Id == request.QuestionId);
               
               if (questionToRemove == null)
               {
                   throw new EntityNotFoundException($"Question {request.QuestionId} was not found.");
               }
               
               quiz.Questions.Remove(questionToRemove);
               dbContext.SaveChangesAsync();

               return Unit.Value;
           });
        }
    }
}
