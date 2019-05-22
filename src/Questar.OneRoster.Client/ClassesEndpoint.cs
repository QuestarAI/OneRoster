namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
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