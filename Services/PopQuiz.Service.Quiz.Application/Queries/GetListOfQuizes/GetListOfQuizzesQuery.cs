using MediatR;
using PopQuiz.Service.Quiz.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Application.Queries.GetListOfQuizes
{
    public class GetListOfQuizzesQuery : IRequest<GetListOfQuizesQueryResponse>
    {
    }
}
