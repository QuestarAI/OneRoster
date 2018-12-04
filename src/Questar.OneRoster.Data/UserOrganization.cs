namespace Questar.OneRoster.Data
{
    using System;

    public class UserOrganization
    {
        private UserOrganization()
        {
        }

        public UserOrganization(Org organization) => Organization = organization;

        public virtual User User { get; private set; }

        public virtual Guid UserId { get; private set; }

        public virtual Org Organization { get; private set; }

        public virtual Guid OrganizationId { get; private set; }
    }
}