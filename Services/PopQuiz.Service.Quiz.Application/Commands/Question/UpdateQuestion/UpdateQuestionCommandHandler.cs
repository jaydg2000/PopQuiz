using MediatR;
using PopQuiz.Service.Common.Exceptions;
using PopQuiz.Service.Quiz.Domain.Entities;
using PopQuiz.Service.Quiz.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PopQuiz.Service.Quiz.Application.Commands.UpdateQuestion
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, Unit>
    {
        private QuizDbContext dbContext;

        public UpdateQuestionCommandHandler(QuizDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var quiz = await dbContext.FindQuizAsync(request.QuizId, cancellationToken);
            Ensure(quiz, request.QuizId);
            quiz.UpdateQuestion(request.QuestionId, request.NewText);
            await dbContext.SaveChangesAsync(cancellationToken);

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
