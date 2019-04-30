namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class CourseEndpoint : ItemEndpoint<Course>, ICourseEndpoint
    {
        public CourseEndpoint(string host, string path) : base(host, path)
        {
        }

        public IListEndpoint<Class> Classes { get; }
        public IListEndpoint<Resource> Resources { get; }
    }
}