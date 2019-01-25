using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PopQuiz.Service.Quiz.Application.Interfaces.Repository;

namespace PopQuiz.Service.Quiz.Persistence.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly QuizDbContext _dbContext;

        protected QuizDbContext DbContext => _dbContext;

        public Repository(QuizDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(T entity)
        {
            if (entity == null)
                return;

            _dbContext.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            if (entity == null)
                return;

            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }
    }
}
