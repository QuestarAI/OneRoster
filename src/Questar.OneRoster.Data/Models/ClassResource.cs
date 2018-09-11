namespace Questar.OneRoster.Data.Models
{
    using System;

    public class ClassResource
    {
        public virtual Class Class { get; set; }

        public virtual Guid ClassId { get; private set; }

        public virtual Resource Resource { get; set; }

        public virtual Guid ResourceId { get; private set; }
    }
}