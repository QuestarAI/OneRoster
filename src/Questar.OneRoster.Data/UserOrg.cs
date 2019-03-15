namespace Questar.OneRoster.Data
{
    using System;

    public class UserOrg
    {
        private UserOrg()
        {
        }

        public UserOrg(Org org) => Org = org;

        public virtual User User { get; private set; }

        public virtual Guid UserId { get; private set; }

        public virtual Org Org { get; private set; }

        public virtual Guid OrgId { get; private set; }
    }
}