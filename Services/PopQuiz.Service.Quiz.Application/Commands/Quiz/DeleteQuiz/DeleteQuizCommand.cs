using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Application.Commands.DeleteQuiz
{
    public class DeleteQuizCommand : IRequest<Unit>
    {
        public int QuizId { get; set; }
    }
}
