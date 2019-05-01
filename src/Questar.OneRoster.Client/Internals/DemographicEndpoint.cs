namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class DemographicEndpoint : ListEndpoint<Demographics>
    {
        public DemographicEndpoint(string path) : base(path)
        {
        }

        public DemographicsEndpoint For(Guid id) => new DemographicsEndpoint($"{Path}/{id}") { Http = Http };
    }
}