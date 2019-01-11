using System.Collections.Generic;
using Xunit;
using static PopQuiz.Service.Identity.Domain.Role.RoleTypes;

namespace PopQuiz.Service.Identity.Domain.Test
{
    public class User_ctorShould
    {
        public User_ctorShould()
        {
        }

        [Fact]
        public void BuildAUser()
        {
            string userId = "TestUserId";
            string firstName = "First";
            string lastName = "Last";
            IdentityToken token = new IdentityToken(userId);
            var roles = GetUserRoles();

            var target = new User(1, userId, firstName, lastName, token, roles);

            Assert.Equal(userId, target.UserId);
            Assert.Equal(firstName, target.FirstName);
            Assert.Equal(lastName, target.LastName);
            Assert.NotEmpty(target.Token.Token);
        }

        private List<Role> GetUserRoles()
        {
            return new List<Role>()
            {
                new Role(Guest, "Guest")
            };
        }
    }
}
