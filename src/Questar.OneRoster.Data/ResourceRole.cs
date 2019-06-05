namespace Questar.OneRoster.Data
{
    public class ResourceRole
    {
        internal ResourceRole()
        {
        }

        public ResourceRole(UserType role)
        {
            Role = role;
        }

        public virtual Resource Resource { get; internal set; }

        public virtual int ResourceId { get; internal set; }

        public virtual UserType Role { get; internal set; }
    }
}