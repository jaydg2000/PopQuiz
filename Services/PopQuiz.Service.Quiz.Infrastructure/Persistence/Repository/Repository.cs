using Microsoft.EntityFrameworkCore;
using PopQuiz.Service.Quiz.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PopQuiz.Service.Quiz.Infrastructure.Persistence.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        protected readonly DbContext context;
        protected readonly DbSet<T> entities;

        public Repository(DbContext dbContext)
        {
            this.context = dbContext;
            this.entities = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            entities.Add(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return entities.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList() as IEnumerable<T>;
        }

        public T Get(int id)
        {
            return entities.Find(id);
        }

        public void Remove(T entity)
        {
            entities.Remove(entity);
        }
    }
}
