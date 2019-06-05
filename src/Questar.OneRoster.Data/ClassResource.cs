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

        public virtual int ClassId { get; internal set; }

        public virtual Resource Resource { get; internal set; }

        public virtual int ResourceId { get; internal set; }
    }
}