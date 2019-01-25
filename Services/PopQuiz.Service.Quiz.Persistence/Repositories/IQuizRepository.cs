using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PopQuiz.Service.Quiz.Application.Interfaces.Repository;

namespace PopQuiz.Service.Quiz.Persistence.Repositories
{
    public interface IQuizRepository : IRepository<Domain.Entities.Quiz>
    {
        Task<IEnumerable<Domain.Entities.Quiz>> GetQuizesByAuthor(int authorId);
        Task<IEnumerable<Domain.Entities.Quiz>> GetQuizesByKeywords(params string[] keywords);
    }
}
