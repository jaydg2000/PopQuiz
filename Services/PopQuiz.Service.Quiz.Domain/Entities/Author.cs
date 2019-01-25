using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Domain.Entities
{
    public class Author
    {
        public int UserId { get; }
        public string Fullname { get; }
        public ICollection<Quiz> Quizes { get; set; }

        public Author(int userId, string fullname)
        {
            UserId = userId;
            Fullname = fullname;
        }
    }
}
