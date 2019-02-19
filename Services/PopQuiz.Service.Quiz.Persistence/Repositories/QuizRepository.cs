using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PopQuiz.Service.Quiz.Persistence.Repositories
{
    public class QuizRepository : Repository<Domain.Entities.Quiz>, IQuizRepository
    {
        public QuizRepository(QuizDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Domain.Entities.Quiz>> GetQuizesByAuthor(int authorId)
        {
            return await DbContext.Quizes
                .Where(q => q.Author.UserId == authorId).ToListAsync();

        }

        public async Task<IEnumerable<Domain.Entities.Quiz>> GetQuizesByKeywords(params string[] keywords)
        {
            return await DbContext.Quizes.Include(q => q.Author)
                .Where( q => keywords.Any(kw => q.Name.Contains(kw) || q.Description.Contains(kw))).ToListAsync();
        }
    }
}
