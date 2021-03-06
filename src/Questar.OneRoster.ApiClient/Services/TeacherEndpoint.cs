namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class TeacherEndpoint : ItemEndpoint<User>
    {
        public TeacherEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public TeacherClassesEndpoint Classes => new TeacherClassesEndpoint(Http, $"{Path}/classes");
    }
}