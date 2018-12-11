using MediatR;
using PopQuiz.Service.Quiz.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using PopQuiz.Service.Quiz.Domain.Entities;
using PopQuiz.Service.Common.Exceptions;

namespace PopQuiz.Service.Quiz.Application.Commands.Choice.DeleteChoice
{
    internal class DeleteChoiceCommandHandler : IRequestHandler<DeleteChoiceCommand, Unit>
    {
        private QuizDbContext dbContext;

        public DeleteChoiceCommandHandler(QuizDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Unit> Handle(DeleteChoiceCommand request, CancellationToken cancellationToken)
        {
            return Task<Unit>.Factory.StartNew(() =>
            {
                Question question = dbContext.FindQuestionWithChoice(request.ChoiceId);

                if (question == null)
                {
                    throw new EntityNotFoundException("A Question with Choice", request.ChoiceId);
                }

                question.RemoveChoice(request.ChoiceId);
                dbContext.SaveChanges();

                return Unit.Value;
            });
        }
    }
}
