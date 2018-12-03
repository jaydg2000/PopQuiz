using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Application.Models
{
    public class AddChoiceCommandResponse
    {
        public int NewChoiceId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
