namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class DemographicsEndpoint : ListEndpoint<Demographics>, IDemographicsEndpoint
    {
        public DemographicsEndpoint(string host, string path) : base(host, path)
        {
        }

        public IItemEndpoint<Demographics> For(Guid id) => throw new NotImplementedException();
    }
}