using System.Collections.Generic;

namespace PopQuiz.Service.Quiz.Application.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public IEnumerable<ChoiceViewModel> Choices { get; set; }
    }
}