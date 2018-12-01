using Microsoft.AspNetCore.Mvc;
using PopQuiz.Service.Quiz.Application.Commands.AddQuestion;
using PopQuiz.Service.Quiz.Application.Commands.CreateQuiz;
using PopQuiz.Service.Quiz.Application.Commands.DeleteQuestion;
using PopQuiz.Service.Quiz.Application.Commands.DeleteQuiz;
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

        [HttpDelete]
        [Route("{quizid:int}/question/{questionid:int}")]
        public async Task<IActionResult> DeleteQuestion(int quizId, int questionId)
        {
            var command = new DeleteQuestionCommand()
            {
                QuizId = quizId,
                QuestionId = questionId
            };

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [Route("{quizid:int}")]
        public async Task<IActionResult> DeleteQuiz(int quizId)
        {
            var command = new DeleteQuizCommand()
            {
                QuizId = quizId
            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}