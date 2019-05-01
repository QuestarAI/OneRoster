namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class ClassStudentsEndpoint : ListEndpoint<User>, IClassStudentsEndpoint
    {
        public ClassStudentsEndpoint(string path) : base(path)
        {
        }

        public IListEndpoint<Result> ResultsFor(Guid id) => new ListEndpoint<Result>($"{Path}/lineItems");
    }
}