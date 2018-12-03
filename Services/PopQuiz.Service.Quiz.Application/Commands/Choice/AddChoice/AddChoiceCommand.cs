using MediatR;
using PopQuiz.Service.Quiz.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Application.Commands.Choice.AddChoice
{
    public class AddChoiceCommand : IRequest<AddChoiceCommandResponse>
    {
        public int QuizId { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
