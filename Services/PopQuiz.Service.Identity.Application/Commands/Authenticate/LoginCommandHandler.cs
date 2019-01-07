using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PopQuiz.Service.Identity.Domain;

namespace PopQuiz.Service.Identity.Application.Commands.Authenticate
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        // TODO: Replace with user db.
        private static Tuple<string, string, string> userQuizCreator = new Tuple<string, string, string>("QuizCreator", "Quiz", "Creator");
        private static Tuple<string, string, string> userQuizTaker = new Tuple<string, string, string>("QuizTaker", "Quiz", "Taker");
        private static Tuple<string, string, string> userAdmin = new Tuple<string, string, string>("AccountAdmin", "Account", "Admin");

        public Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var userNames = GetUserNames(request.userId);
                IdentityToken token = new IdentityToken(request.userId);
                User user = new User(
                    request.userId, 
                    userNames.Item1, 
                    userNames.Item2, 
                    token,
                    GetUserRoles(request.userId));

                return new LoginCommandResponse(user, (userNames.Item1!="Guest"));
            }, cancellationToken);
        }

        // TODO: Will be retrieved from user db.
        private Tuple<string, string> GetUserNames(string userId)
        {
            if (userId == userQuizCreator.Item1)
                return new Tuple<string, string>(userQuizCreator.Item2, userQuizCreator.Item3);
            if (userId == userQuizTaker.Item1)
                return new Tuple<string, string>(userQuizTaker.Item2, userQuizTaker.Item3);
            if (userId == userAdmin.Item1)
                return new Tuple<string, string>(userAdmin.Item2, userAdmin.Item3);

            return new Tuple<string, string>("Guest", "User");
        }

        // TODO: Will be retrieved from user db.
        private IEnumerable<UserRole> GetUserRoles(string userId)
        {
            if (userId == userQuizCreator.Item1)
                return new List<UserRole>(){ UserRole.QuizCreator, UserRole.QuizTaker };
            if (userId == userQuizTaker.Item1)
                return new List<UserRole>() { UserRole.QuizTaker };
            if (userId == userAdmin.Item1)
                return new List<UserRole>() { UserRole.Admin, UserRole.QuizCreator, UserRole.QuizTaker };

            return new List<UserRole>() { UserRole.Guest };
        }
    }
}
