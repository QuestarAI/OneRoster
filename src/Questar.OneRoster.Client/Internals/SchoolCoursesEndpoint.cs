namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class SchoolCoursesEndpoint : ListEndpoint<Course>
    {
        public SchoolCoursesEndpoint(string path) : base(path)
        {
        }
    }
}