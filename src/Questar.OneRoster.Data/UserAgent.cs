namespace Questar.OneRoster.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserAgent
    {
        private UserAgent()
        {
        }

        public UserAgent(User agent) =>
            Agent = agent;

        public virtual User User { get; private set; }

        [Required]
        public virtual string UserId { get; private set; }

        public virtual User Agent { get; private set; }

        [Required]
        public virtual string AgentId { get; private set; }
    }
}