using System.Collections.Generic;

namespace Questar.OneRoster.Models
{
    public class User : Base
    {
        public string Username { get; set; }

        public ICollection<UserId> UserIds { get; set; }

        public bool EnabledUser { get; set; }

        public string GivenName { get; set; }

        public string FamilyName { get; set; }

        public string MiddleName { get; set; }

        public RoleType Role { get; set; }

        public string Identifier { get; set; }

        public string Email { get; set; }

        public string Sms { get; set; }

        public string Phone { get; set; }

        public ICollection<GuidRef> Agents { get; set; }

        public ICollection<GuidRef> Orgs { get; set; }

        public ICollection<string> Grades { get; set; }

        public string Password { get; set; }
    }
}