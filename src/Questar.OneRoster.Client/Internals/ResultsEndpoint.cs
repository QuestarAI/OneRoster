namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class ResultsEndpoint : ListEndpoint<Result>
    {
        public ResultsEndpoint(string path) : base(path)
        {
        }

        public ResultEndpoint For(Guid id) => new ResultEndpoint($"{Path}/{id}") { Http = Http };
    }
}