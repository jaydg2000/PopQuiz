using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Application.Commands.Choice.DeleteChoice
{
    public class DeleteChoiceCommand : IRequest<Unit>
    {
        public int QuizId { get; set; }
        public int QuestionId { get; set; }
        public int ChoiceId { get; set; }
    }
}
