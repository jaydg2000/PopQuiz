using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Application.Commands.Choice.DeleteChoice
{
    public class DeleteChoiceCommand : IRequest<Unit>
    {
        public int ChoiceId { get; set; }
    }
}
