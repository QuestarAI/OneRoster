namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class ResultsEndpoint : ListEndpoint<Result>, IResultsEndpoint
    {
        public ResultsEndpoint(string host, string path) : base(host, path)
        {
        }

        public IEditEndpoint<Result> For(Guid id) => throw new NotImplementedException();
    }
}