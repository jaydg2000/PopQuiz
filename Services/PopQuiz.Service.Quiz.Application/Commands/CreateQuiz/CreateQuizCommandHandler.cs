using MediatR;
using PopQuiz.Service.Quiz.Application.Interfaces.Repository;
using PopQuiz.Service.Quiz.Application.Models;
using PopQuiz.Service.Quiz.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PopQuiz.Service.Quiz.Application.Commands.CreateQuiz
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, QuizCreatedViewModel>
    {
        private IUnitOfWork unitOfWork;

        public CreateQuizCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<QuizCreatedViewModel> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            IQuizRepository quizRepository = unitOfWork.Quizes;

            ProctoredQuiz quiz = new ProctoredQuiz(request.Name, request.Description);
            quizRepository.Add(quiz);
            unitOfWork.Commit();

            QuizCreatedViewModel model = new QuizCreatedViewModel()
            {
                Id = quiz.Id,
                Name = quiz.Name,
                Description = quiz.Description
            };

            return model;
        }
    }
}
