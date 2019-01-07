using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PopQuiz.Service.Identity.Domain.Test
{
    public class User_AddRole_Should
    {
        private User user;

        public User_AddRole_Should()
        {
            var userId = "john123";
            user = new User(userId, "John", "Doe", IdentityToken.Empty);
        }

        [Fact]
        public void AddInitialRoleToUser()
        {
            user.AddRole(UserRole.Guest);
            Assert.Contains(UserRole.Guest, user.Roles);
        }

        [Fact]
        public void AddAdditionalRoleToUser()
        {
            user.AddRole(UserRole.QuizTaker);
            user.AddRole(UserRole.QuizCreator);
            Assert.Contains(UserRole.QuizTaker, user.Roles);
            Assert.Contains(UserRole.QuizCreator, user.Roles);
        }
    }
}
