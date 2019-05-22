namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class ClassesEndpoint : ListEndpoint<Class>
    {
        public ClassesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public ClassEndpoint For(string id) =>
            new ClassEndpoint(Http, $"{Path}/{id}");
    }
}