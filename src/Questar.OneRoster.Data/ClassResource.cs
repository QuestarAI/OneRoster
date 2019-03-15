namespace Questar.OneRoster.Data
{
    using System;

    public class ClassResource
    {
        public ClassResource(Resource resource) => Resource = resource;

        private ClassResource()
        {
        }

        public virtual Class Class { get; private set; }

        public virtual Guid ClassId { get; private set; }

        public virtual Resource Resource { get; private set; }

        public virtual Guid ResourceId { get; private set; }
    }
}