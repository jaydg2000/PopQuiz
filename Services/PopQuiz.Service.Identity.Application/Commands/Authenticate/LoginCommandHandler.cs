using MediatR;
using PopQuiz.Service.Identity.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static PopQuiz.Service.Identity.Domain.Role.RoleTypes;

namespace PopQuiz.Service.Identity.Application.Commands.Authenticate
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        // TODO: Replace with user db.
        private static readonly Tuple<string, string, string> UserQuizCreator = new Tuple<string, string, string>("QuizCreator", "Quiz", "Creator");
        private static readonly Tuple<string, string, string> UserQuizTaker = new Tuple<string, string, string>("QuizTaker", "Quiz", "Taker");
        private static readonly Tuple<string, string, string> UserAdmin = new Tuple<string, string, string>("AccountAdmin", "Account", "Admin");

        public Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var userNames = GetUserNames(request.userId);
                var token = new IdentityToken(request.userId);
                User user = null;
                //new User(
                //    1, // TODO: hardcoded key
                //    request.userId, 
                //    userNames.Item1, 
                //    userNames.Item2, 
                //    token,
                //    GetUserRoles(request.userId));

                return new LoginCommandResponse(user, (userNames.Item1!="Guest"));
            }, cancellationToken);
        }

        // TODO: Will be retrieved from user db.
        private Tuple<string, string> GetUserNames(string userId)
        {
            if (userId == UserQuizCreator.Item1)
                return new Tuple<string, string>(UserQuizCreator.Item2, UserQuizCreator.Item3);
            if (userId == UserQuizTaker.Item1)
                return new Tuple<string, string>(UserQuizTaker.Item2, UserQuizTaker.Item3);
            if (userId == UserAdmin.Item1)
                return new Tuple<string, string>(UserAdmin.Item2, UserAdmin.Item3);

            return new Tuple<string, string>("Guest", "User");
        }

        //// TODO: Will be retrieved from user db.
        //private IEnumerable<UserRole> GetUserRoles(string userId)
        //{
        //    if (userId == UserQuizCreator.Item1)
        //        return new List<UserRole>(){ new UserRole()
        //        {
                    
        //        }};
        //    if (userId == UserQuizTaker.Item1)
        //        return new List<UserRole>() { QuizTaker };
        //    if (userId == UserAdmin.Item1)
        //        return new List<UserRole>() { Admin, QuizCreator, QuizTaker };

        //    return new List<UserRole>() { Guest };
        //}
    }
}
