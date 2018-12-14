using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace PopQuiz.Service.Quiz.Application.Commands.UpdateChoice
{
    public class UpdateChoiceCommand : IRequest<Unit>
    {
        public int QuizId { get; set; }
        public int ChoiceId { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
