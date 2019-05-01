namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class ResultsEndpoint : ListEndpoint<Result>, IResultsEndpoint
    {
        public ResultsEndpoint(string path) : base(path)
        {
        }

        public IEditEndpoint<Result> For(Guid id) => new EditEndpoint<Result>($"{Path}/{id}");
    }
}