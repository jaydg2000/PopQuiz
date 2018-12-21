using MediatR;

namespace PopQuiz.Service.Quiz.Application.Commands.UpdateQuiz
{
    public class UpdateQuizCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
