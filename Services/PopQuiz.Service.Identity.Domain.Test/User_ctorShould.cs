using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

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
            var roles = new List<UserRole>(){UserRole.Guest};

            var target = new User(userId, firstName, lastName, token, roles);

            Assert.Equal(userId, target.UserId);
            Assert.Equal(firstName, target.FirstName);
            Assert.Equal(lastName, target.LastName);
            Assert.NotEmpty(target.Token.Token);
        }
    }
}
