using MediatR;
using PopQuiz.Service.Quiz.Application.Models;
using PopQuiz.Service.Quiz.Domain.Entities;
using PopQuiz.Service.Quiz.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PopQuiz.Service.Quiz.Application.Queries.GetListOfQuizes
{
    internal class GetListOfQuizzesQueryHandler : IRequestHandler<GetListOfQuizzesQuery, GetListOfQuizesQueryResponse>
    {
        private readonly QuizDbContext _dbContext;

        public GetListOfQuizzesQueryHandler(QuizDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<GetListOfQuizesQueryResponse> Handle(GetListOfQuizzesQuery request, CancellationToken cancellationToken)
        {
            var quizList = await _dbContext.Quizes.ToListAsync(cancellationToken);
            return new GetListOfQuizesQueryResponse()
            {
                QuizSummaries = await CreateListOfQuizSummaries(quizList)
            };
        }

        private static Task<List<QuizSummaryViewModel>> CreateListOfQuizSummaries(IEnumerable<ProctoredQuiz> quizList)
        {
            return Task.Run(() => (from quiz in quizList.AsParallel()
                                   select new QuizSummaryViewModel()
                                   {
                                       Id = quiz.Id,
                                       Name = quiz.Name,
                                       Description = quiz.Description
                                   }).ToList());
        }
    }
}
