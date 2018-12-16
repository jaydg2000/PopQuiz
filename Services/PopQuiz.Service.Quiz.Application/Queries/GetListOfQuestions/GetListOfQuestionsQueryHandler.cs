using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PopQuiz.Service.Quiz.Application.Models;
using PopQuiz.Service.Quiz.Domain.Entities;
using PopQuiz.Service.Quiz.Persistence;


namespace PopQuiz.Service.Quiz.Application.Queries.GetListOfQuestions
{
    public class GetListOfQuestionsQueryHandler
        : IRequestHandler<GetListOfQuestionsQuery, GetListOfQuestionsQueryResponse>
    {
        private readonly QuizDbContext _dbContext;

        public GetListOfQuestionsQueryHandler(QuizDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetListOfQuestionsQueryResponse> Handle(GetListOfQuestionsQuery request, CancellationToken cancellationToken)
        {
            var questions = await _dbContext.FindQuestionsForQuiz(request.QuizId, cancellationToken);

            return new GetListOfQuestionsQueryResponse()
            {
                Questions = (from question in questions.AsParallel().AsOrdered()
                    select new QuestionViewModel()
                    {
                        Id = question.Id,
                        Text = question.Text,
                        Choices =
                            from choice in question.Choices
                            select new ChoiceViewModel()
                            {
                                Id = choice.Id,
                                Text = choice.Text,
                                IsCorrect = choice.IsCorrect
                            }
                    }).ToList()
            };
        }
    }
}
