using Microsoft.EntityFrameworkCore;
using PopQuiz.Service.Quiz.Application.Interfaces;
using PopQuiz.Service.Quiz.Application.Interfaces.Repository;
using PopQuiz.Service.Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PopQuiz.Service.Quiz.Infrastructure.Persistence.Repository
{
    public class QuizRepository : Repository<ProctoredQuiz>, IQuizRepository
    {
        public QuizRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
