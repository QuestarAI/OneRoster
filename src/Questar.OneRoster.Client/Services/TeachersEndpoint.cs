namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class TeachersEndpoint : ListEndpoint<User>
    {
        public TeachersEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public TeacherEndpoint For(string id) =>
            new TeacherEndpoint(Http, $"{Path}/{id}");
    }
}