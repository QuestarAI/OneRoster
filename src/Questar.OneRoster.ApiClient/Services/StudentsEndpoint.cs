namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class StudentsEndpoint : ListEndpoint<User>
    {
        public StudentsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public StudentEndpoint For(string id) =>
            new StudentEndpoint(Http, $"{Path}/{id}");
    }
}