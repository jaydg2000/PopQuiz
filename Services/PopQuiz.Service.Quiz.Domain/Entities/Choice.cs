using PopQuiz.Service.Common.Domain.Infrastructure;

namespace PopQuiz.Service.Quiz.Domain.Entities
{
    public class Choice : DomainEntity
    {
        private Choice() { }

        public Choice(string text, bool isCorrect)
            : this(0, text, isCorrect)
        {
        }

        public Choice(int id, string text, bool isCorrect)
            : base(id)
        {
            Text = text;
            IsCorrect = isCorrect;
        }

        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public Question Question { get; set; }
    }
}