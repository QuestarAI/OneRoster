namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class CourseClassesEndpoint : ListEndpoint<Class>
    {
        public CourseClassesEndpoint(string path) : base(path)
        {
        }
    }
}