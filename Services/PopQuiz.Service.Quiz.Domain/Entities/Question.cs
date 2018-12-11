using PopQuiz.Service.Common.Domain.Infrastructure;
using PopQuiz.Service.Common.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace PopQuiz.Service.Quiz.Domain.Entities
{
    public class Question : DomainEntity
    {
        private List<Choice> choices;

        public string Text { get; set; }
        public ProctoredQuiz Quiz { get; set; }
        public IEnumerable<Choice> Choices => choices;

        private Question(): this(0, string.Empty) { }

        public Question(int id, string text) : base(id)
        {
            this.Text = text;
            choices = new List<Choice>();
        }

        public Question(string text)
            : this(0, text)
        {
        }

        public void AddChoice(Choice choice)
        {
            choices.Add(choice);
        }

        public void RemoveChoice(int id)
        {
            Choice choiceToRemove = choices.FirstOrDefault(ch => ch.Id == id);

            if (choiceToRemove == null)
            {
                throw new EntityNotFoundException("Choice", id);
            }

            choices.Remove(choiceToRemove);
        }
    }
}