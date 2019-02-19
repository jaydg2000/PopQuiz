using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace PopQuiz.Service.Identity.Domain
{
    public class User
    {
        private readonly List<UserRole> _userRolesXRef;

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public IdentityToken Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<UserRole> UserRoles => _userRolesXRef;
        public IEnumerable<Role> Roles => 
            (from ur in _userRolesXRef
            select ur.Role).ToList();

        private User()
        {
        }

        public User(int id, string userId, string firstName, string lastName, IdentityToken token, IEnumerable<Role> roles = null)
        {
            Id = id;
            UserId = userId;
            Token = token;
            FirstName = firstName;
            LastName = lastName;

            _userRolesXRef = new List<UserRole>();
            if (roles != null)
            {
                Parallel.ForEach(roles, (role) => AddRole(role));
            }
        }

        public void AddRole(Role role)
        {
            UserRole userRole = new UserRole()
            {
                User = this,
                UserId = this.Id,
                Role = role,
                RoleId = role.Id
            };
            _userRolesXRef.Add(userRole);
        }
        
    }
}
