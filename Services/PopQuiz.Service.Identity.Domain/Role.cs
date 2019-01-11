using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Identity.Domain
{
    public class Role
    {
        private readonly List<UserRole> _roles;

        public enum RoleTypes
        {
            Guest,
            Admin,
            QuizTaker,
            QuizCreator
        }

        public int Id { get; set; }
        public RoleTypes RoleType { get; set; }
        public string Description { get; set; }
        public IEnumerable<UserRole> UserRoles => _roles;


        private Role()
        {
        }

        public Role(RoleTypes role, string description)
        {
            RoleType = role;
            Description = description;
        }
    }
}
