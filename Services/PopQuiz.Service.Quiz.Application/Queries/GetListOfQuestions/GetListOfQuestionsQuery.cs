using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PopQuiz.Service.Quiz.Application.Models;

namespace PopQuiz.Service.Quiz.Application.Queries.GetListOfQuestions
{
    public class GetListOfQuestionsQuery : IRequest<GetListOfQuestionsQueryResponse>
    {
        public int QuizId { get; set; }
    }
}
