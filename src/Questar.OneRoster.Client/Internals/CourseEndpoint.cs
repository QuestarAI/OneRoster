namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class CourseEndpoint : ItemEndpoint<Course>
    {
        public CourseEndpoint(string path) : base(path)
        {
        }

        public CourseClassesEndpoint Classes => new CourseClassesEndpoint($"{Path}/classes") { Http = Http };
        public CourseResourcesEndpoint Resources => new CourseResourcesEndpoint($"{Path}/resources") { Http = Http };
    }
}