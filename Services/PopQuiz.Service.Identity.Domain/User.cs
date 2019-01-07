using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Identity.Domain
{
    public class User
    {
        private readonly List<UserRole> _roles;

        public string UserId { get; }
        public IdentityToken Token { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public IEnumerable<UserRole> Roles => _roles;

        public User(string userId, string firstName, string lastName, IdentityToken token, IEnumerable<UserRole> roles = null)
        {
            UserId = userId;
            Token = token;
            FirstName = firstName;
            LastName = lastName;

            _roles = new List<UserRole>();
            if (roles != null)
            {
                _roles.AddRange(roles);
            }
        }

        public void AddRole(UserRole role)
        {
            _roles.Add(role);
        }

    }
}
