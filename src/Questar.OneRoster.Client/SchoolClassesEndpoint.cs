namespace Questar.OneRoster.Client
{
    using System;
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class SchoolClassesEndpoint : ListEndpoint<Class>
    {
        public SchoolClassesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public SchoolClassEndpoint For(Guid id) => new SchoolClassEndpoint(Http, $"{Path}/{id}");
    }
}