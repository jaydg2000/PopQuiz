using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace PopQuiz.Service.Quiz.Controllers
{
    public class PopQuizController : Controller
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

    }
}