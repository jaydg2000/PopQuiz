using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Application.Commands.DeleteQuestion
{
    public class DeleteQuestionCommand : IRequest
    {
        public int QuestionId { get; set; }
        public int QuizId { get; set; }
    }
}
