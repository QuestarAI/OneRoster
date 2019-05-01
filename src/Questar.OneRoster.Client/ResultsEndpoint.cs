namespace Questar.OneRoster.Client
{
    using System;
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class ResultsEndpoint : ListEndpoint<Result>
    {
        public ResultsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public ResultEndpoint For(Guid id) => new ResultEndpoint(Http, $"{Path}/{id}");
    }
}