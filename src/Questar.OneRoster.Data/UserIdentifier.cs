using System.ComponentModel.DataAnnotations;

namespace Questar.OneRoster.Data
{
    public class UserIdentifier
    {
        public UserIdentifier(string type, string identifier)
        {
            Type = type;
            Identifier = identifier;
        }

        internal UserIdentifier()
        {
        }

        public virtual User User { get; internal set; }

        public virtual int UserId { get; internal set; }

        [Required] [MaxLength(256)] public virtual string Type { get; internal set; }

        [Required] [MaxLength(256)] public virtual string Identifier { get; internal set; }
    }
}