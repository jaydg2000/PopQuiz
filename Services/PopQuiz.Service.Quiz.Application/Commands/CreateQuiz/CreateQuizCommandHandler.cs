using MediatR;
using PopQuiz.Service.Quiz.Application.Models;
using PopQuiz.Service.Quiz.Domain.Entities;
using PopQuiz.Service.Quiz.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace PopQuiz.Service.Quiz.Application.Commands.CreateQuiz
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, QuizCreatedViewModel>
    {
        readonly private QuizDbContext dbContext;

        public CreateQuizCommandHandler(QuizDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<QuizCreatedViewModel> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            return Task<QuizCreatedViewModel>.Factory.StartNew(() =>
                {
                    ProctoredQuiz quiz = new ProctoredQuiz(request.Name, request.Description);
                    dbContext.Quizes.Add(quiz);

                    QuizCreatedViewModel model = new QuizCreatedViewModel()
                    {
                        Id = quiz.Id,
                        Name = quiz.Name,
                        Description = quiz.Description
                    };

                    return model;
                });
        }
    }
}
