namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class SchoolCoursesEndpoint : ListEndpoint<Course>
    {
        public SchoolCoursesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}