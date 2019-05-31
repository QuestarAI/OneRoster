namespace Questar.OneRoster.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CourseResource
    {
        public CourseResource(Resource resource) =>
            Resource = resource;

        private CourseResource()
        {
        }

        public virtual Course Course { get; private set; }

        [Required]
        public virtual string CourseId { get; private set; }

        public virtual Resource Resource { get; private set; }

        [Required]
        public virtual string ResourceId { get; private set; }
    }
}