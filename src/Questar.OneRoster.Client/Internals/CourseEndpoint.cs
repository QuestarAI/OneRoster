namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class CourseEndpoint : ItemEndpoint<Course>, ICourseEndpoint
    {
        public CourseEndpoint(string path) : base(path)
        {
        }

        public IListEndpoint<Class> Classes => new ListEndpoint<Class>($"{Path}/classes");
        public IListEndpoint<Resource> Resources => new ListEndpoint<Resource>($"{Path}/resources");
    }
}