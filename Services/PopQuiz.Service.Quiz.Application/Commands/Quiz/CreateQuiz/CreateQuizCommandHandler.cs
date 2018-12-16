using MediatR;
using PopQuiz.Service.Quiz.Application.Models;
using PopQuiz.Service.Quiz.Domain.Entities;
using PopQuiz.Service.Quiz.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace PopQuiz.Service.Quiz.Application.Commands.CreateQuiz
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, CreateQuizCommandResponse>
    {
        private readonly QuizDbContext _dbContext;

        public CreateQuizCommandHandler(QuizDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<CreateQuizCommandResponse> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = new Domain.Entities.Quiz(request.Name, request.Description);
            await _dbContext.Quizes.AddAsync(quiz, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var model = new CreateQuizCommandResponse()
            {
                Id = quiz.Id,
                Name = quiz.Name,
                Description = quiz.Description
            };

            return model;
        }
    }
}
