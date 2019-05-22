namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class SchoolClassesEndpoint : ListEndpoint<Class>
    {
        public SchoolClassesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public SchoolClassEndpoint For(string id) => new SchoolClassEndpoint(Http, $"{Path}/{id}");
    }
}