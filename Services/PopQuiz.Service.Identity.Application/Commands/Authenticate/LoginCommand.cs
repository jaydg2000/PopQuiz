using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace PopQuiz.Service.Identity.Application.Commands.Authenticate
{
    public class LoginCommand : IRequest<LoginCommandResponse>
    {
        public string userId { get; set; }
        public string password { get; set; }
        public bool rememberMe { get; set; }
    }
}
