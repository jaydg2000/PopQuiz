﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace PopQuiz.Service.Quiz.Controllers
{
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
    }
}