using MediatR;
using PopQuiz.Service.Quiz.Application.Interfaces.Repository;
using PopQuiz.Service.Quiz.Application.Models;
using PopQuiz.Service.Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace PopQuiz.Service.Quiz.Application.Queries.GetListOfQuizes
{
    public class GetListOfQuizesQueryHandler : IRequestHandler<GetListOfQuizesQuery, QuizListViewModel>
    {
        IUnitOfWork unitOfWork;

        public GetListOfQuizesQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<QuizListViewModel> Handle(GetListOfQuizesQuery request, CancellationToken cancellationToken)
        {
            QuizListViewModel viewModel = new QuizListViewModel()
            {
                QuizSummaries = CreateListOfQuizSummaries(unitOfWork.Quizes.GetAll())
            };

            return viewModel;
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
