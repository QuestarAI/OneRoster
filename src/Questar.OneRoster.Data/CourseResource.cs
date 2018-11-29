namespace Questar.OneRoster.Data
{
    using System;

    public class CourseResource
    {
        public CourseResource(Resource resource)
        {
            Resource = resource;
        }

        private CourseResource()
        {
        }

        public virtual Course Course { get; private set; }

        public virtual Guid CourseId { get; private set; }

        public virtual Resource Resource { get; private set; }

        public virtual Guid ResourceId { get; private set; }
    }
}