using MediatR;

namespace PopQuiz.Service.Quiz.Application.Commands.UpdateQuiz
{
    public class UpdateQuizCommand : IRequest<Unit>
    {
        public int QuizId { get; set; }
        public string NewName { get; set; }
        public string NewDescription { get; set; }
    }
}
