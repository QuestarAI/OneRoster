namespace Questar.OneRoster.Data.Models
{
    using System;

    public class CourseResource
    {
        public virtual Course Course { get; set; }

        public virtual Guid CourseId { get; private set; }

        public virtual Resource Resource { get; set; }

        public virtual Guid ResourceId { get; private set; }
    }
}