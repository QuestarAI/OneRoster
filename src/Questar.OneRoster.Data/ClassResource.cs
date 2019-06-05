namespace Questar.OneRoster.Data
{
    public class ClassResource
    {
        public ClassResource(Resource resource)
        {
            Resource = resource;
        }

        internal ClassResource()
        {
        }

        public virtual Class Class { get; internal set; }

        public virtual string ClassId { get; internal set; }

        public virtual Resource Resource { get; internal set; }

        public virtual string ResourceId { get; internal set; }
    }
}