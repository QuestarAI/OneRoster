namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class SchoolCoursesEndpoint : ListEndpoint<Course>
    {
        public SchoolCoursesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}