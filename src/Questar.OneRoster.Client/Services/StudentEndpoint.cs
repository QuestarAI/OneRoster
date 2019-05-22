namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class StudentEndpoint : ItemEndpoint<User>
    {
        public StudentEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public StudentClassesEndpoint Classes => new StudentClassesEndpoint(Http, $"{Path}/classes");
    }
}