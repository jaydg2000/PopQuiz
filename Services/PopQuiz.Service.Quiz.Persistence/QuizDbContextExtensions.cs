using Microsoft.EntityFrameworkCore;
using PopQuiz.Service.Common.Exceptions;
using PopQuiz.Service.Quiz.Domain.Entities;
using System.Linq;

namespace PopQuiz.Service.Quiz.Persistence
{
    public static class QuizDbContextExtensions
    {
        public static ProctoredQuiz FindQuiz(this QuizDbContext dbContext, int quizId)
            => (from quiz in dbContext.Quizes
                where quiz.Id == quizId
                select quiz)
                    .Include(q => q.Questions)
                    .ThenInclude(qs => qs.Choices)
                    .FirstOrDefault();

        public static ProctoredQuiz FindQuizWithQuestion(this QuizDbContext dbContext, int questionId)
            => (from quiz in dbContext.Quizes
                from qu in quiz.Questions
                where qu.Id == questionId
                select quiz)
                    .Include(q => q.Questions)
                    .ThenInclude(qs => qs.Choices)
                    .FirstOrDefault();

        public static Question FindQuestion(this QuizDbContext dbContext, int questionId)
            => (from quiz in dbContext.Quizes
                from qu in quiz.Questions
                where qu.Id == questionId
                select qu)
                    .Include(qs => qs.Choices)
                    .FirstOrDefault();

        public static Question FindQuestionWithChoice(this QuizDbContext dbContext, int choiceId)
            => (from quiz in dbContext.Quizes
                from qu in quiz.Questions
                from ch in qu.Choices
                where ch.Id == choiceId
                select qu)
                    .Include(q => q.Quiz)
                    .Include(q => q.Choices)
                    .FirstOrDefault();
    }
}
