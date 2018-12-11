using PopQuiz.Service.Common.Domain.Infrastructure;
using PopQuiz.Service.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PopQuiz.Service.Quiz.Domain.Entities
{
    public class ProctoredQuiz : DomainEntity
    {
        private List<Question> questions;
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<Question> Questions => questions;

        private ProctoredQuiz():this(0,string.Empty) { }

        public ProctoredQuiz(string name, string description = "")
            : this(0, name, description)
        {
        }

        public ProctoredQuiz(int id, string name, string description = "")
            : base(id)
        {            
            this.Name = name;
            this.Description = description;
            questions = new List<Question>();
        }

        public void AddQuestion(Question question)
        {
            this.questions.Add(question);
        }

        public void RemoveQuestion(int id)
        {
            var questionToRemove = Questions.FirstOrDefault(q => q.Id == id);

            if (questionToRemove == null)
            {
                throw new EntityNotFoundException($"Question {id} was not found.");
            }

            questions.Remove(questionToRemove);
        }
    }
}
