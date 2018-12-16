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
        public Quiz Quiz { get; set; }
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

        public Choice AddChoice(string text, bool isCorrect)
        {
            var newChoice = new Choice(text, isCorrect);
            choices.Add(newChoice);

            return newChoice;
        }

        public void RemoveChoice(int id)
        {
            var choiceToRemove = FindChoice(id);

            choices.Remove(choiceToRemove);
        }

        public void UpdateChoice(int id, string text, bool isCorrect)
        {
            Choice choiceToUpdate = FindChoice(id);
            choiceToUpdate.Text = text;
            choiceToUpdate.IsCorrect = isCorrect;
        }

        private Choice FindChoice(int id)
        {
            Choice choice = choices.FirstOrDefault(ch => ch.Id == id);

            if (choice == null)
            {
                throw new EntityNotFoundException("Choice", id);
            }

            return choice;
        }
    }
}