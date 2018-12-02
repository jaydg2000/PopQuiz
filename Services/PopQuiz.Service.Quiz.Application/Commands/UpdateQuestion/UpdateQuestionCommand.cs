using MediatR;
using PopQuiz.Service.Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Application.Commands.UpdateQuestion
{
    public class UpdateQuestionCommand : IRequest<Unit>
    {
        public int QuestionId { get; set; }
        public int QuizId { get; set; }
        public string NewText { get; set; }        
    }
}
