using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using static PopQuiz.Service.Identity.Domain.Role.RoleTypes;

namespace PopQuiz.Service.Identity.Domain.Test
{
    public class User_AddRole_Should
    {
        private User user;

        public User_AddRole_Should()
        {
            var userId = "john123";
            user = new User(1, userId, "John", "Doe", IdentityToken.Empty);
        }

        [Fact]
        public void AddInitialRoleToUser()
        {
            Role roleGuest = GetRole(Guest);
            user.AddRole(roleGuest);
            Assert.Contains(roleGuest, user.Roles);
        }

        [Fact]
        public void AddAdditionalRoleToUser()
        {
            Role roleQuizTaker = GetRole(QuizTaker);
            Role roleQuizCreator = GetRole(QuizCreator);
            user.AddRole(roleQuizTaker);
            user.AddRole(GetRole(QuizCreator));
            Assert.Contains(roleQuizTaker, user.Roles);
            Assert.Contains(roleQuizCreator, user.Roles);
        }

        private Role GetRole(Role.RoleTypes roleType) 
            => new Role(roleType, roleType.ToString());
    }
}
