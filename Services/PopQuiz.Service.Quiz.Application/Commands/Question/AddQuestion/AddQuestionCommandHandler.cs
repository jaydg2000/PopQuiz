using System;
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

        public async Task<AddQuestionCommandResponse> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {
            var quiz = await dbContext.FindQuizAsync(request.QuizId, cancellationToken);
            Ensure(quiz, request.QuizId);
            var question = quiz.AddQuestion(request.Text, GetChoiceList(request.Answers));

            await dbContext.SaveChangesAsync(cancellationToken);

            var response = new AddQuestionCommandResponse()
            {
                Id = question.Id,
                Answers = request.Answers
            };

            return response;
        }

        private IEnumerable<Tuple<string, bool>> GetChoiceList(IEnumerable<AddedChoice> choices)
        {
            var requestChoices = new List<Tuple<string, bool>>();
            foreach (AddedChoice choice in choices)
            {
                requestChoices.Add(new Tuple<string, bool>(choice.Text, choice.IsCorrect));
            }

            return from choice in choices.AsParallel().AsOrdered()
                select new Tuple<string, bool>(choice.Text, choice.IsCorrect);
        }
        
        private static void Ensure(ProctoredQuiz quiz, int quizId)
        {
            if (quiz == null)
            {
                throw new EntityNotFoundException("Quiz", quizId);
            }
        }
    }
}
