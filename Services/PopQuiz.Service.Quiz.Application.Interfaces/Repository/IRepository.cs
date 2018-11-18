using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PopQuiz.Service.Quiz.Application.Interfaces.Repository
{
    public interface IRepository<T>
    {
        void Add(T entity);

        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Remove(T entity);
    }
}
