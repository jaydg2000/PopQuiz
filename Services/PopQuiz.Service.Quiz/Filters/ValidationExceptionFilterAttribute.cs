using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PopQuiz.Service.Common.Exceptions;

namespace PopQuiz.Service.Quiz.Filters
{
    public class ValidationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException
                || context.Exception is RequestExpectationException)
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
