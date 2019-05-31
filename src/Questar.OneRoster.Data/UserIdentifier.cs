namespace Questar.OneRoster.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserIdentifier
    {
        public UserIdentifier(string type, string identifier)
        {
            Type = type;
            Identifier = identifier;
        }

        private UserIdentifier()
        {
        }

        public virtual User User { get; private set; }

        [Required]
        public virtual string UserId { get; private set; }

        [Required]
        [MaxLength(256)]
        public virtual string Type { get; private set; }

        [Required]
        [MaxLength(256)]
        public virtual string Identifier { get; private set; }
    }
}