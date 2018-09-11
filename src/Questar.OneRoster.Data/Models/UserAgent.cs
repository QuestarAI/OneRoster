namespace Questar.OneRoster.Data.Models
{
    using System;

    public class UserAgent
    {
        private UserAgent()
        {
        }

        public UserAgent(User agent)
        {
            Agent = agent;
        }

        public virtual User User { get; private set; }

        public virtual Guid UserId { get; private set; }

        public virtual User Agent { get; private set; }

        public virtual Guid AgentId { get; private set; }
    }
}