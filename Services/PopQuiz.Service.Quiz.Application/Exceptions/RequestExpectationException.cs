using PopQuiz.Service.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Application.Exceptions
{
    public class RequestExpectationException : ServiceOperationException
    {
        public RequestExpectationException(string message) : base(message)
        {
        }
    }
}
