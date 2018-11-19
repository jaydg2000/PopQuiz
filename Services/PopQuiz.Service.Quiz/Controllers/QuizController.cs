using Microsoft.AspNetCore.Mvc;
using PopQuiz.Service.Quiz.Application.Commands.CreateQuiz;
using MediatR;
using System.Threading.Tasks;
using PopQuiz.Service.Quiz.Application.Queries.GetListOfQuizes;
using System;

namespace PopQuiz.Service.Quiz.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : PopQuizController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllQuizes()
        {
            return Ok(await Mediator.Send(new GetListOfQuizesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizCommand createQuizCommand)
        {
            return Ok(await Mediator.Send(createQuizCommand));
        }
    }
}