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

        public Task<Unit> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            return Task<Unit>.Factory.StartNew(() => 
            {
                ProctoredQuiz quiz = dbContext.Quizes.FirstOrDefault(q => q.Id == request.QuizId);
                Ensure(quiz, request.QuizId);

                Question questionToUpdate = quiz.Questions.FirstOrDefault(q => q.Id == request.QuestionId);
                Ensure(questionToUpdate, request.QuestionId, request.QuizId);

                questionToUpdate.Text = request.NewText;
                dbContext.SaveChanges();

                return Unit.Value;
            });
        }

        private void Ensure(ProctoredQuiz quiz, int quizId)
        {
            if (quiz == null)
            {
                throw new EntityNotFoundException($"Quiz {quizId} was not found.");
            }
        }

        private void Ensure(Question question, int questionId, int quizId)
        {
            if (question == null)
            {
                throw new EntityNotFoundException($"Question {questionId} of Quiz {quizId} was not found.");
            }
        }
    }
}
