using PopQuiz.Service.Common.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Domain.Entities
{
    public class ProctoredQuiz : DomainEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public ProctoredQuiz(string name, string description = "")
            : this(0, name, description)
        {
        }

        public ProctoredQuiz(int id, string name, string description = "")
            : base(id)
        {            
            this.Name = name;
            this.Description = description;
        }
    }
}
