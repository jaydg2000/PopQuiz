using PopQuiz.Service.Quiz.Domain.Entities;
using System.Collections.Generic;

namespace PopQuiz.Service.Quiz.Application.Models
{
    public class AddQuestionCommandResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public IEnumerable<AddedChoice> Answers { get; set; }
    }
}