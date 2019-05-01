namespace Questar.OneRoster.Client
{
    using System;
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class ClassesEndpoint : ListEndpoint<Class>
    {
        public ClassesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public ClassEndpoint For(Guid id) => new ClassEndpoint(Http, $"{Path}/{id}");
    }
}