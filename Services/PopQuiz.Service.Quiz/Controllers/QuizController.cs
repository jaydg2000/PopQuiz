using Microsoft.AspNetCore.Mvc;
using PopQuiz.Service.Quiz.Application.Commands.AddQuestion;
using PopQuiz.Service.Quiz.Application.Commands.CreateQuiz;
using PopQuiz.Service.Quiz.Application.Models;
using PopQuiz.Service.Quiz.Application.Queries.GetListOfQuizes;
using System.Threading.Tasks;

namespace PopQuiz.Service.Quiz.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllQuizes()
        {
            return Ok(await Mediator.Send(new GetListOfQuizesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizCommand createQuizCommand)
        {
            CreateQuizCommandResponse response = await Mediator.Send(createQuizCommand);
            return Created(GetLocationUrl(response.Id), response);
        }

        [HttpPost]
        [Route("question")]
        public async Task<IActionResult> CreateQuestion([FromBody] AddQuestionCommand addQuestionCommand)
        {
            AddQuestionCommandResponse response = await Mediator.Send(addQuestionCommand);
            return Created(GetLocationUrl(response.Id), response);
        }

    }
}