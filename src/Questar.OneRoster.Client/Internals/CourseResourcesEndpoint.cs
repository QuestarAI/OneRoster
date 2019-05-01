namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class CourseResourcesEndpoint : ListEndpoint<Resource>
    {
        public CourseResourcesEndpoint(string path) : base(path)
        {
        }
    }
}