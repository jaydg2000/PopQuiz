using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PopQuiz.Service.Common.Exceptions;
using PopQuiz.Service.Quiz.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PopQuiz.Service.Quiz.Persistence
{
    public static class QuizDbContextExtensions
    {
        public static async Task<Domain.Entities.Quiz> FindQuizAsync(
            this QuizDbContext dbContext,
            int quizId,
            CancellationToken cancellationToken)
        =>
            await (from quiz in dbContext.Quizes
                   where quiz.Id == quizId
                   select quiz)
                .Include(q => q.Questions)
                .ThenInclude(qs => qs.Choices)
                .FirstOrDefaultAsync(cancellationToken);

        public static async Task<IEnumerable<Question>> FindQuestionsForQuiz(
            this QuizDbContext dbContext,
            int quizId,
            CancellationToken cancellationToken)
        =>
            await (from quiz in dbContext.Quizes
                   from question in quiz.Questions
                   where quiz.Id == quizId
                   select question).Include(qu => qu.Choices).ToListAsync(cancellationToken);
    }
}
