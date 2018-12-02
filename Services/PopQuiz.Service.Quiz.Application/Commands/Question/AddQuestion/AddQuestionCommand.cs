using MediatR;
using PopQuiz.Service.Quiz.Application.Models;
using System.Collections.Generic;

namespace PopQuiz.Service.Quiz.Application.Commands.AddQuestion
{
    public class AddQuestionCommand : IRequest<AddQuestionCommandResponse>
    {
        public int QuizId { get; set; }
        public string Text { get; set; }
        public IEnumerable<AddedChoice> Answers { get; set; }

        public AddQuestionCommand()
        {
            Answers = new List<AddedChoice>();
        }
    }
}
