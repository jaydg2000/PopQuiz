using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PopQuiz.Service.Common.Exceptions;
using PopQuiz.Service.Quiz.Filters;
using System;

namespace PopQuiz.Service.Quiz.Controllers
{
    [ValidationExceptionFilter]
    public abstract class ControllerBase : Controller
    {
        private IMediator mediator;

        protected IMediator Mediator {
            get {
                if (mediator == null)
                {
                    mediator = HttpContext.RequestServices.GetService<IMediator>();
                }
                return mediator;
            }
        }

        protected string GetLocationUrl(int resourceId)
        {
            return $"~{Request.Path}/{resourceId}";
        }

        protected void Expect<T>(T obj, Func<T,bool> expectation)
        {
            if (!expectation(obj))
            {
                throw new RequestExpectationException("The request was not valid.");
            }
        }
    }
}