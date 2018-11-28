using PopQuiz.Service.Common.Domain.Infrastructure;

namespace PopQuiz.Service.Quiz.Domain.Entities
{
    public class Choice : DomainEntity
    {
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

        public string Text { get; private set; }
        public bool IsCorrect { get; private set; }
    }
}