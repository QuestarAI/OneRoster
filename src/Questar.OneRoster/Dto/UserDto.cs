namespace Questar.OneRoster.Dto
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Vocabulary;
    using Vocabulary.Ceds;

    public class UserDto<TGrade> : Base
    {
        public string Username { get; set; }
        public IEnumerable<UserId> UserIds { get; set; } = Enumerable.Empty<UserId>();
        public bool EnabledUser { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string MiddleName { get; set; }
        public RoleType Role { get; set; }
        public string Identifier { get; set; }
        public string Email { get; set; }
        public string Sms { get; set; }
        public string Phone { get; set; }
        public IEnumerable<GuidRef> Agents { get; set; } = Enumerable.Empty<GuidRef>();
        public IEnumerable<GuidRef> Orgs { get; set; } = Enumerable.Empty<GuidRef>();
        public IEnumerable<TGrade> Grades { get; set; } = Enumerable.Empty<TGrade>();
        public string Password { get; set; }
    }

    public class UserDto : UserDto<Grade> { }
}