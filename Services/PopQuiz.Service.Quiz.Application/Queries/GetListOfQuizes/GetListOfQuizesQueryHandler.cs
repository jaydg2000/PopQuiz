using MediatR;
using PopQuiz.Service.Quiz.Application.Models;
using PopQuiz.Service.Quiz.Domain.Entities;
using PopQuiz.Service.Quiz.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PopQuiz.Service.Quiz.Application.Queries.GetListOfQuizes
{
    internal class GetListOfQuizesQueryHandler : IRequestHandler<GetListOfQuizesQuery, QuizListViewModel>
    {
        readonly private QuizDbContext dbContext;

        public GetListOfQuizesQueryHandler(QuizDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<QuizListViewModel> Handle(GetListOfQuizesQuery request, CancellationToken cancellationToken)
        {
            return Task<QuizListViewModel>.Factory.StartNew(() =>
            {

                QuizListViewModel viewModel = new QuizListViewModel()
                {
                    QuizSummaries = CreateListOfQuizSummaries(dbContext.Quizes.ToList())
                };

                return viewModel;

            });
        }

        private IEnumerable<QuizSummaryViewModel> CreateListOfQuizSummaries(IEnumerable<ProctoredQuiz> quizes)
        {
            return (from quiz in quizes
                    select new QuizSummaryViewModel()
                    {
                        Id = quiz.Id,
                        Name = quiz.Name,
                        Description = quiz.Description
                    }).ToList();
        }
    }
}
