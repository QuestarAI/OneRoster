namespace Questar.OneRoster.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ClassResource
    {
        public ClassResource(Resource resource) =>
            Resource = resource;

        private ClassResource()
        {
        }

        public virtual Class Class { get; private set; }

        [Required]
        public virtual string ClassId { get; private set; }

        public virtual Resource Resource { get; private set; }

        [Required]
        public virtual string ResourceId { get; private set; }
    }
}