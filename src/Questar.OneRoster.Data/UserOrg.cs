namespace Questar.OneRoster.Data
{
    public class UserOrg
    {
        internal UserOrg()
        {
        }

        public UserOrg(Org org)
        {
            Org = org;
        }

        public virtual User User { get; internal set; }

        public virtual string UserId { get; internal set; }

        public virtual Org Org { get; internal set; }

        public virtual string OrgId { get; internal set; }
    }
}