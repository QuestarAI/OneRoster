namespace Questar.OneRoster.Data
{
    public class CourseResource
    {
        public CourseResource(Resource resource)
        {
            Resource = resource;
        }

        internal CourseResource()
        {
        }

        public virtual Course Course { get; internal set; }

        public virtual string CourseId { get; internal set; }

        public virtual Resource Resource { get; internal set; }

        public virtual string ResourceId { get; internal set; }
    }
}