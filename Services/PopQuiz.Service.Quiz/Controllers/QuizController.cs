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
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using PopQuiz.Service.Quiz.Application.Commands.UpdateChoice;
using PopQuiz.Service.Quiz.Application.Queries.GetListOfQuestions;

namespace PopQuiz.Service.Quiz.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : PopQuizServiceControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllQuizes()
        {
            return Ok(await Mediator.Send(new GetListOfQuizzesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizCommand createQuizCommand)
        {
            Expect(createQuizCommand, c => c != null);

            CreateQuizCommandResponse response = await Mediator.Send(createQuizCommand);
            return Created(GetLocationUrl(response.Id), response);
        }

        [HttpPut]
        [Route("{quizId:int}")]
        public async Task<IActionResult> UpdateQuiz(int quizId, [FromBody] UpdateQuizCommand updateQuizCommand)
        {
            Expect(updateQuizCommand, c => c != null);
            Expect(updateQuizCommand, c => c.QuizId == quizId);

            await Mediator.Send(updateQuizCommand);
            return NoContent();
        }


        [HttpDelete]
        [Route("{quizId:int}")]
        public async Task<IActionResult> DeleteQuiz(int quizId)
        {
            var command = new DeleteQuizCommand()
            {
                QuizId = quizId
            };

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        [Route("{quizId}/question")]
        public async Task<IActionResult> GetListOfQuesions(int quizId)
        {
            Expect(quizId, c => c > 0);
            return Ok(await Mediator.Send(new GetListOfQuestionsQuery() {QuizId = quizId}));
        }

        [HttpPost]
        [Route("{quizId:int}/question")]
        public async Task<IActionResult> CreateQuestion(int quizId, [FromBody] AddQuestionCommand addQuestionCommand)
        {
            Expect(addQuestionCommand, c => c != null);
            Expect(addQuestionCommand, c => c.QuizId == quizId);
            AddQuestionCommandResponse response = await Mediator.Send(addQuestionCommand);
            return Created(GetLocationUrl(response.Id), response);
        }

        [HttpPut]
        [Route("{quizId:int}/question/{questionId:int}")]
        public async Task<IActionResult> UpdateQuestion(int quizId, int questionId, [FromBody] UpdateQuestionCommand updateQuestionCommand)
        {
            Expect(updateQuestionCommand, c => c != null);
            Expect(updateQuestionCommand, c => c.QuizId == quizId);
            Expect(updateQuestionCommand, c => c.QuestionId == questionId);

            await Mediator.Send(updateQuestionCommand);
            return NoContent();
        }

        [HttpDelete]
        [Route("{quizId:int}/question/{questionId:int}")]
        public async Task<IActionResult> DeleteQuestion(int quizId, int questionId)
        {
            Expect(quizId, (id) => id > 0);
            Expect(questionId, (id) => id > 0);
            var command = new DeleteQuestionCommand()
            {
                QuizId = quizId,
                QuestionId = questionId
            };

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPost]
        [Route("{quizId:int}/question/{questionId:int}/choice")]
        public async Task<IActionResult> AddChoice(int quizId, int questionId, [FromBody] AddChoiceCommand addChoiceCommand)
        {
            Expect(addChoiceCommand, c => c != null);
            Expect(addChoiceCommand, c => c.QuizId == quizId);
            Expect(addChoiceCommand, c => c.QuestionId == questionId);

            AddChoiceCommandResponse response = await Mediator.Send(addChoiceCommand);
            return Created(GetLocationUrl(response.NewChoiceId), response);
        }

        [HttpDelete]
        [Route("{quizId:int}/question/{questionId:int}/choice/{choiceId:int}")]
        public async Task<IActionResult> DeleteChoice(int quizId, int questionId, int choiceId)
        {
            Expect(quizId, c => c > 0);
            Expect(questionId, c => c > 0);
            Expect(choiceId, c => c > 0);

            var deleteChoiceCommand = new DeleteChoiceCommand()
            {
                QuizId = quizId,
                QuestionId = questionId,
                ChoiceId = choiceId
            };

            await Mediator.Send(deleteChoiceCommand);

            return NoContent();
        }

        [HttpPut]
        [Route("{quizId:int}/question/{questionId:int}/choice/{choiceId:int}")]
        public async Task<IActionResult> UpdateChoice(int quizId, int questionId, int choiceId, [FromBody] UpdateChoiceCommand updateChoiceCommand)
        {
            Expect(updateChoiceCommand, c => c != null);
            Expect(updateChoiceCommand, c => c.QuizId == quizId);
            Expect(updateChoiceCommand, c => c.QuestionId == questionId);
            Expect(updateChoiceCommand, c => c.ChoiceId == choiceId);

            await Mediator.Send(updateChoiceCommand);

            return NoContent();
        }
    }
}