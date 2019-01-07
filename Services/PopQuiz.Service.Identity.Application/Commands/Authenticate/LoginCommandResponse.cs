using System.Security.Principal;
using MediatR;
using PopQuiz.Service.Identity.Domain;

namespace PopQuiz.Service.Identity.Application.Commands.Authenticate
{
    public class LoginCommandResponse : IRequest<Unit>
    {
        private readonly User _user;
        private readonly bool _wasSuccessful;

        public User User => _user;
        public bool WasSuccessful => _wasSuccessful;

        public LoginCommandResponse(User user, bool successful)
        {
            _user = user;
            _wasSuccessful = successful;
        }
    }
}