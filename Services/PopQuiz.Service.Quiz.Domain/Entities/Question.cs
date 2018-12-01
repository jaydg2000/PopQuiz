using PopQuiz.Service.Common.Domain.Infrastructure;
using System.Collections.Generic;

namespace PopQuiz.Service.Quiz.Domain.Entities
{
    public class Question : DomainEntity
    {
        public string Text { get; private set; }
        public ProctoredQuiz Quiz { get; set; }
        public virtual ICollection<Choice> Choices { get; set; }

        public Question(int id, string text) : base(id)
        {
            this.Text = text;
            Choices = new List<Choice>();
        }

        public Question(string text)
            : this(0, text)
        {
        }
    }
}