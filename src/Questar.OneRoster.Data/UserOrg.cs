namespace Questar.OneRoster.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserOrg
    {
        private UserOrg()
        {
        }

        public UserOrg(Org org) =>
            Org = org;

        public virtual User User { get; private set; }

        [Required]
        public virtual string UserId { get; private set; }

        public virtual Org Org { get; private set; }

        [Required]
        public virtual string OrgId { get; private set; }
    }
}