namespace Questar.OneRoster.Data.Models
{
    using System;

    public class ResourcePosition
    {
        private ResourcePosition()
        {
        }

        public ResourcePosition(Position position)
        {
            Position = position;
        }

        public Guid Id { get; private set; } // this is a container, not a relationship type, so it requires its own id for 1-*

        public virtual Resource Resource { get; private set; }

        public virtual Guid ResourceId { get; private set; }

        public virtual Position Position { get; private set; }
    }
}