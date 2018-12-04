using MediatR;
using PopQuiz.Service.Common.Exceptions;
using PopQuiz.Service.Quiz.Application.Models;
using PopQuiz.Service.Quiz.Domain.Entities;
using PopQuiz.Service.Quiz.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PopQuiz.Service.Quiz.Application.Commands.AddQuestion
{
    public class AddQuestionCommandHandler : IRequestHandler<AddQuestionCommand, AddQuestionCommandResponse>
    {
        QuizDbContext dbContext;

        public AddQuestionCommandHandler(QuizDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<AddQuestionCommandResponse> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {
            return Task<AddQuestionCommandResponse>.Factory.StartNew(() =>
            {
                ProctoredQuiz quiz = FindQuiz(request);
                Question question = BuildQuestion(request);                
                quiz.AddQuestion(question);
                dbContext.SaveChanges();

                var response = new AddQuestionCommandResponse()
                {
                    Id = question.Id,
                    Answers = BuildResponseChoices(question)
                };

                return response;
            });
        }

        private IEnumerable<AddedChoice> BuildResponseChoices(Question question)
        {
            return (from choice in question.Choices
                    select new AddedChoice() {
                        Text = choice.Text,
                        IsCorrect = choice.IsCorrect
                    }).ToList();
        }

        private ProctoredQuiz FindQuiz(AddQuestionCommand request)
        {
            ProctoredQuiz quiz = dbContext.Quizes.Find(request.QuizId);
            if (quiz == null)
            {
                throw new EntityNotFoundException($"Quiz {request.QuizId} was not found.");
            }
            return quiz;
        }

        private static Question BuildQuestion(AddQuestionCommand request)
        {
            Question question = new Question(request.Text);
            foreach (AddedChoice addedChoice in request.Answers)
            {
                question.AddChoice(new Domain.Entities.Choice(addedChoice.Text, addedChoice.IsCorrect));
            }

            return question;
        }
    }
}
