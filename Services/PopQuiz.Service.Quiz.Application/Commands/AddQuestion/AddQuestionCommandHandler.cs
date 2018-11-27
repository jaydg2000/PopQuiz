using MediatR;
using PopQuiz.Service.Quiz.Application.Exceptions;
using PopQuiz.Service.Quiz.Application.Models;
using PopQuiz.Service.Quiz.Domain.Entities;
using PopQuiz.Service.Quiz.Persistence;
using System.Collections.Generic;
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
                quiz.Questions.Add(question);
                dbContext.SaveChanges();

                return new AddQuestionCommandResponse()
                {
                    NewId = question.Id
                };
            });
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
                question.Choices.Add(new Choice(addedChoice.Text, addedChoice.IsCorrect));
            }

            return question;
        }
    }
}
