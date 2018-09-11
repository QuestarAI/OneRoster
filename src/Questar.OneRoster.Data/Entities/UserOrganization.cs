namespace Questar.OneRoster.Data.Entities
{
    using System;

    public class UserOrganization
    {
        private UserOrganization()
        {
        }

        public UserOrganization(Organization organization)
        {
            Organization = organization;
        }

        public virtual User User { get; private set; }

        public virtual Guid UserId { get; private set; }

        public virtual Organization Organization { get; private set; }

        public virtual Guid OrganizationId { get; private set; }
    }
}