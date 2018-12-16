using PopQuiz.Service.Common.Domain.Infrastructure;
using PopQuiz.Service.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PopQuiz.Service.Quiz.Domain.Entities
{
    public class Quiz : DomainEntity
    {
        private readonly List<Question> _questions;
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Question> Questions => _questions;

        private Quiz():this(0,string.Empty) { }

        public Quiz(string name, string description = "")
            : this(0, name, description)
        {
        }

        public Quiz(int id, string name, string description = "")
            : base(id)
        {            
            this.Name = name;
            this.Description = description;
            _questions = new List<Question>();
        }

        #region Operations on Questions
        public Question AddQuestion(string text, IEnumerable<Tuple<string, bool>> choices)
        {
            var question = new Question(text);
            foreach (var choice in choices)
            {
                question.AddChoice(choice.Item1, choice.Item2);
            }
            _questions.Add(question);

            return question;
        }

        public void RemoveQuestion(int id)
        {
            var questionToRemove = _questions.FirstOrDefault(q => q.Id == id);

            if (questionToRemove == null)
            {
                throw new EntityNotFoundException($"Question {id} was not found.");
            }

            _questions.Remove(questionToRemove);
        }

        public void UpdateQuestion(int questionId, string text)
        {
            var question = _questions.FirstOrDefault(q => q.Id == questionId);
            if (question == null)
            {
                throw new EntityNotFoundException($"Question {questionId} was not found.");
            }
            question.Text = text;
        }

        #endregion Operations on Questions

        #region Operations on Choices
        public Choice AddChoiceToQuestion(int questionId, string text, bool isCorrect)
        {
            var question = _questions.FirstOrDefault(q => q.Id == questionId);
            return question?.AddChoice(text, isCorrect);
        }

        public void RemoveChoiceFromQuestion(int questionId, int choiceId)
        {
            var question = _questions.FirstOrDefault(q => q.Id == questionId);
            question?.RemoveChoice(choiceId);
        }

        public void UpdateChoiceInQuestion(int questionId, int choiceId, string text, bool isCorrect)
        {
            var question = _questions.FirstOrDefault(q => q.Id == questionId);
            question?.UpdateChoice(choiceId, text, isCorrect);
        }
        #endregion Operations on Choices
    }
}
