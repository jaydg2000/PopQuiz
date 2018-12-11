using Microsoft.AspNetCore.Mvc;
using PopQuiz.Service.Common.Web.Controllers;
using PopQuiz.Service.Quiz.Application.Commands.AddQuestion;
using PopQuiz.Service.Quiz.Application.Commands.Choice.AddChoice;
using PopQuiz.Service.Quiz.Application.Commands.Choice.DeleteChoice;
using PopQuiz.Service.Quiz.Application.Commands.CreateQuiz;
using PopQuiz.Service.Quiz.Application.Commands.DeleteQuestion;
using PopQuiz.Service.Quiz.Application.Commands.DeleteQuiz;
using PopQuiz.Service.Quiz.Application.Commands.UpdateQuestion;
using PopQuiz.Service.Quiz.Application.Commands.UpdateQuiz;
using PopQuiz.Service.Quiz.Application.Models;
using PopQuiz.Service.Quiz.Application.Queries.GetListOfQuizes;
using System.Threading.Tasks;

namespace PopQuiz.Service.Quiz.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : PopQuizServiceControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllQuizes()
        {
            return Ok(await Mediator.Send(new GetListOfQuizesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizCommand createQuizCommand)
        {
            Expect(createQuizCommand, c => c != null);

            CreateQuizCommandResponse response = await Mediator.Send(createQuizCommand);
            return Created(GetLocationUrl(response.Id), response);
        }

        [HttpPut]
        [Route("{quizid:int}")]
        public async Task<IActionResult> UpdateQuiz(int quizId, [FromBody] UpdateQuizCommand updateQuizCommand)
        {
            Expect(updateQuizCommand, c => c != null);
            Expect(updateQuizCommand, c => c.QuizId == quizId);

            await Mediator.Send(updateQuizCommand);
            return NoContent();
        }

        [HttpPost]
        [Route("question")]
        public async Task<IActionResult> CreateQuestion([FromBody] AddQuestionCommand addQuestionCommand)
        {
            AddQuestionCommandResponse response = await Mediator.Send(addQuestionCommand);
            return Created(GetLocationUrl(response.Id), response);
        }

        [HttpPut]
        [Route("{quizid:int}/question/{questionid:int}")]
        public async Task<IActionResult> UpdateQuestion(int quizId, int questionId, [FromBody] UpdateQuestionCommand updateQuestionCommand)
        {
            Expect(updateQuestionCommand, c => c != null);
            Expect(updateQuestionCommand, c => c.QuizId == quizId);
            Expect(updateQuestionCommand, c => c.QuestionId == questionId);

            await Mediator.Send(updateQuestionCommand);
            return NoContent();
        }

        [HttpDelete]
        [Route("question/{questionid:int}")]
        public async Task<IActionResult> DeleteQuestion(int questionId)
        {
            Expect(questionId, (id) => id > 0);
            var command = new DeleteQuestionCommand()
            {
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

        [HttpPost]
        [Route("{quizid:int}/question/{questionid:int}/choice")]
        public async Task<IActionResult> AddChoice(int quizId, int questionId, [FromBody] AddChoiceCommand addChoiceCommand)
        {
            Expect(addChoiceCommand, c => c != null);
            Expect(addChoiceCommand, c => c.QuizId == quizId);
            Expect(addChoiceCommand, c => c.QuestionId == questionId);

            AddChoiceCommandResponse response = await Mediator.Send(addChoiceCommand);
            return Created(GetLocationUrl(response.NewChoiceId), response);
        }

        [HttpDelete]
        [Route("question/choice/{choiceid:int}")]
        public async Task<IActionResult> DeleteChoice(int choiceId)
        {
            Expect(choiceId, c => c > 0);

            var deleteChoiceCommand = new DeleteChoiceCommand()
            {
                ChoiceId = choiceId
            };

            await Mediator.Send(deleteChoiceCommand);

            return NoContent();
        }
    }
}