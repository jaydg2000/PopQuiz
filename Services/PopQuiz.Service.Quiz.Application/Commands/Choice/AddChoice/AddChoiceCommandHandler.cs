using MediatR;
using PopQuiz.Service.Common.Exceptions;
using PopQuiz.Service.Quiz.Application.Models;
using PopQuiz.Service.Quiz.Domain.Entities;
using PopQuiz.Service.Quiz.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PopQuiz.Service.Quiz.Application.Commands.Choice.AddChoice
{
    public class AddChoiceCommandHandler : IRequestHandler<AddChoiceCommand, AddChoiceCommandResponse>
    {
        private QuizDbContext dbContext;

        public AddChoiceCommandHandler(QuizDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<AddChoiceCommandResponse> Handle(AddChoiceCommand request, CancellationToken cancellationToken)
        {
            return Task<AddChoiceCommandResponse>.Factory.StartNew(() =>
           {
               Question question = dbContext.Quizes
                    .FirstOrDefault(q => q.Id == request.QuizId)?.Questions
                    .FirstOrDefault(qu => qu.Id == request.QuestionId);

               if (question == null)
               {
                   throw new EntityNotFoundException($"Question {request.QuestionId} of Quiz {request.QuizId} was not found.");
               }

               var newChoice = new Domain.Entities.Choice(request.Text, request.IsCorrect);
               question.AddChoice(newChoice);
               dbContext.SaveChanges();

               return new AddChoiceCommandResponse()
               {
                   NewChoiceId = newChoice.Id,
                   Text = newChoice.Text,
                   IsCorrect = newChoice.IsCorrect
               };
           });
        }
    }
}
