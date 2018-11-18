using Microsoft.AspNetCore.Mvc;
using PopQuiz.Service.Quiz.Application.Commands.CreateQuiz;
using MediatR;
using System.Threading.Tasks;

namespace PopQuiz.Service.Quiz.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : PopQuizController
    {
        [HttpPost]
        public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizCommand createQuizCommand)
        {
            return Ok(await Mediator.Send(createQuizCommand));
        }
    }
}