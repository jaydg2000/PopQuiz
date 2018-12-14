using MediatR;
using PopQuiz.Service.Common.Exceptions;
using PopQuiz.Service.Quiz.Application.Models;
using PopQuiz.Service.Quiz.Domain.Entities;
using PopQuiz.Service.Quiz.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PopQuiz.Service.Common.Infrastructure;

namespace PopQuiz.Service.Quiz.Application.Commands.Choice.AddChoice
{
    public class AddChoiceCommandHandler : IRequestHandler<AddChoiceCommand, AddChoiceCommandResponse>
    {
        private QuizDbContext _dbContext;

        public AddChoiceCommandHandler(QuizDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<AddChoiceCommandResponse> Handle(AddChoiceCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _dbContext.FindQuizAsync(request.QuizId, cancellationToken);
            Ensure.Entity(quiz, "Quiz", request.QuizId);
            var addedChoiceRef = quiz.AddChoiceToQuestion(request.QuestionId, request.Text, request.IsCorrect);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new AddChoiceCommandResponse()
            {
                NewChoiceId = addedChoiceRef.Id,
                Text = request.Text,
                IsCorrect = request.IsCorrect
            };
        }
    }
}
