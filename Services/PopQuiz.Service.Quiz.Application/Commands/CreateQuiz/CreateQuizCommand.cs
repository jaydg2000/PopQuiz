using MediatR;
using PopQuiz.Service.Quiz.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Application.Commands.CreateQuiz
{
    public class CreateQuizCommand : IRequest<QuizCreatedViewModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
