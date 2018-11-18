using Microsoft.EntityFrameworkCore;
using PopQuiz.Service.Quiz.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Infrastructure.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext dbContext;

        public IQuizRepository Quizes { get; private set; }

        public UnitOfWork(DbContext dbContext, IQuizRepository quizRepository)
        {
            this.dbContext = dbContext;
            this.Quizes = quizRepository;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext?.Dispose();
        }
    }
}
