using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using PopQuiz.Service.Quiz.Application.Exceptions;
using PopQuiz.Service.Common.Exceptions;

namespace PopQuiz.Service.Quiz.Filters
{
    public class ValidationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException)
            {
                context.Result = new BadRequestObjectResult(
                    new {
                        context.Exception.Message
                    });
                context.ExceptionHandled = true;
            }

            if (context.Exception is EntityNotFoundException)
            {
                context.Result = new NotFoundObjectResult(
                    new
                    {
                        context.Exception.Message
                    });
                context.ExceptionHandled = true;
            }
        }
    }
}
