namespace Questar.OneRoster.Data
{
    using System;

    public class ResourceRole
    {
        private ResourceRole()
        {
        }

        public ResourceRole(UserType role) => Role = role;

        public virtual Resource Resource { get; private set; }

        public virtual Guid ResourceId { get; private set; }

        public virtual UserType Role { get; private set; }
    }
}